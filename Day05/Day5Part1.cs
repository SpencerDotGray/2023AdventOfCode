using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day05;

public class Day5Part1
{
    public void Main(string path)
    {
        var data = new StreamReader(path).ReadToEnd();
        var parts = data.Split("\r\n\r\n");

        var mappedValues = parts[0].Split(":")[1].Trim().Split(' ').Select(s => BigInteger.Parse(s.Trim()));

        foreach (var map in parts.Skip(1))
        {
            mappedValues = mappedValues.Select(value => map.Split('\n').Skip(1).Aggregate(value, (result, line) =>
            {
                if (result != value)
                    return result;

                var rules = line.Split(' ').Select(s => BigInteger.Parse((s.Trim()))).ToList();
                var min = rules[1];
                var max = rules[1] + rules[2];

                if (value >= min && value <= max)
                {
                    return (value - min) + rules[0];
                }

                return result;
            }));
        }

        Console.WriteLine($"Result: [{mappedValues.Min()}]");
    }
}
