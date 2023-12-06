using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day06;

public class Day6Part2
{
    public void Main(string path)
    {
        var data = new StreamReader(path).ReadToEnd();

        var time = Int64.Parse(data.Split('\n')[0].Trim().Split(':')[1].Trim().Replace(" ", ""));
        var distance = Int64.Parse(data.Split('\n')[1].Trim().Split(':')[1].Trim().Replace(" ", ""));

        var one = (time + Math.Sqrt((double)Math.Pow(time, 2) - 4 * distance)) / 2;
        var two = (time - Math.Sqrt((double)Math.Pow(time, 2) - 4 * distance)) / 2;
        var max = (int)Math.Floor(double.Max(one, two)) - (double.Max(one, two) % 1 == 0 ? 1 : 0);
        var min = (int)Math.Ceiling(double.Min(one, two)) + (double.Min(one, two) % 1 == 0 ? 1 : 0);

        Console.WriteLine($"Result: [{1 + max - min}]");
    }
}
