using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day05;

public class Day5Part2
{
    public void Main(string path)
    {
        var data = new StreamReader(path).ReadToEnd();
        var parts = data.Split("\r\n\r\n");

        var seeds = parts[0].Split(":")[1].Trim().Split(' ').Select(s => BigInteger.Parse(s.Trim())).ToList();
        List<(BigInteger, BigInteger)> seedRanges = new List<(BigInteger, BigInteger)>();

        for (int i = 0; i < seeds.Count; i += 2)
        {
            seedRanges.Add((seeds[i], seeds[i + 1]));
        }

        var maps = parts.Skip(1).ToList();

        foreach (var map in maps)
        {
            var temp = new List<(BigInteger, BigInteger)>();

            foreach (var route in seedRanges)
            {
                temp.AddRange(MapPath(route, map));
            }

            seedRanges = temp;
        }

        Console.WriteLine($"Results: [{seedRanges.Select(i => i.Item1).Min()}]");
    }

    public List<(BigInteger, BigInteger)> MapPath((BigInteger, BigInteger) path, string mapLayout)
    {
        var maps = mapLayout.Split('\n').Skip(1)
            .Select(s => s.Trim().Split(' ').Select(i => BigInteger.Parse(i)).ToList());
        List<(BigInteger, BigInteger)> results = new();
        List<(BigInteger, BigInteger)> skips = new();

        foreach (var map in maps)
        {
            if (path.Item1 + path.Item2 < map[1] || path.Item1 > map[1] + map[2])
            {
                // Outside of range -- for now do nothing
                continue;
            }
            else if (path.Item1 >= map[1] && path.Item1 + path.Item2 <= map[1] + map[2])
            {
                // Fully Inside Range
                results.Add((map[0] + (path.Item1 - map[1]), path.Item2));

                path.Item1 = 0;
                path.Item2 = 0;
            }
            else if (path.Item1 < map[1] && path.Item1 + path.Item2 <= map[1] + map[2])
            {
                // Falls Outside Range On Left
                var length = path.Item2 - (map[1] - path.Item1);
                results.Add((map[0], length));

                path.Item2 -= length;
            }
            else if (path.Item1 >= map[1] && path.Item1 + path.Item2 > map[1] + map[2])
            {
                // Falls Outside Range On Right
                var length = map[2] - (path.Item1 - map[1]);
                results.Add((map[0] + (path.Item1 - map[1]), length));

                path.Item1 += length;
                path.Item2 -= length;
            }
            else if (path.Item1 < map[1] && path.Item1 + path.Item2 > map[1] + map[2])
            {
                // Falls Outside Range On Both Sides
                results.Add((map[0], map[2]));
            }
        }

        if (!(path.Item1 == 0 && path.Item2 == 0))
            results.Add((path.Item1, path.Item2));

        return results;
    }
}
