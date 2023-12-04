using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2023AdventOfCode.Day03;

public class Day3PartOneCode
{
    public void Main(string path)
    {
        // Init
        var data = new StreamReader(path).ReadToEnd();
        List<(int, int)> CoordChecks = new()
        {
            { (1, 0) },
            { (0, 1) },
            { (-1, 0) },
            { (0, -1) },
            { (1, 1) },
            { (-1, -1) },
            { (1, -1) },
            { (-1, 1) },
        };

        // Create Grid
        List<List<char>> grid = data.Split('\n').Select(s => s.Trim().ToCharArray().ToList()).ToList();

        // Get Coords
        List<List<(int, int)>> digits = new();
        for (int i = 0; i < grid.Count; ++i)
        {
            var creatingNumber = false;
            for (int j = 0; j < grid[i].Count; ++j)
            {
                if (!creatingNumber && Char.IsDigit(grid[i][j]))
                {
                    creatingNumber = true;
                    digits.Add(new List<(int, int)>
                    {
                        { (i, j) }
                    });
                }
                else if (creatingNumber && Char.IsDigit(grid[i][j]))
                {
                    digits.Last().Add((i, j));
                }
                else if (creatingNumber)
                {
                    creatingNumber = false;
                }
            }
        }

        // Process Coords
        int result = digits.Aggregate(0, (prod, number) =>
        {
            var excludeNumber = true;
            string numString = "";
            foreach (var digit in number)
            {
                numString += grid[digit.Item1][digit.Item2];
                excludeNumber &= CoordChecks.Select(cord =>
                {
                    try
                    {
                        return grid[digit.Item1 + cord.Item1][digit.Item2 + cord.Item2];
                    } catch
                    {
                        return '.';
                    }
                }).ToList().Aggregate(true, (prod, next) => prod && (next == '.' || char.IsDigit(next)));
            }

            return prod + (!excludeNumber ? int.Parse(numString) : 0);
        });

        Console.WriteLine($"Result: [{result}]");
    }
}
