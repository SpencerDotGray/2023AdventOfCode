using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day06;

public class Day6Part1
{
    public void Main(string path)
    {
        var data = new StreamReader(path).ReadToEnd();
        var times = data.Split('\n')[0].Trim().Split(':')[1].Trim().Split(' ').Where(s => s.Trim() != "").Select(s => int.Parse(s)).ToList();
        var distances = data.Split('\n')[1].Trim().Split(':')[1].Trim().Split(' ').Where(s => s.Trim() != "").Select(s => int.Parse(s)).ToList();

        var result = Enumerable.Range(0, times.Count).Aggregate(1, (total, i) =>
        {
            var one = (times[i] + Math.Sqrt((double)Math.Pow(times[i], 2) - 4 * distances[i])) / 2;
            var two = (times[i] - Math.Sqrt((double)Math.Pow(times[i], 2) - 4 * distances[i])) / 2;
            var max = (int)Math.Floor(double.Max(one, two)) - (double.Max(one, two) % 1 == 0 ? 1 : 0);
            var min = (int)Math.Ceiling(double.Min(one, two)) + (double.Min(one, two) % 1 == 0 ? 1 : 0);

            return total * (1 + max - min);
        });

        Console.WriteLine($"Result: [{result}]");
    }
}
