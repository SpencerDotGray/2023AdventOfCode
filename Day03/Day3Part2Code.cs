using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day03;

public class Day3Part2Code
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

        // Get Number and Gear Coords
        List<Digit> digits = new();
        List<(int, int)> gears = new();

        for (int i = 0; i < grid.Count; ++i)
        {
            bool inDigit = false;
            for (int j = 0; j < grid[i].Count; ++j)
            {
                if (char.IsDigit(grid[i][j]))
                {
                    if (!inDigit)
                    {
                        digits.Add(new Digit
                        {
                            ID = digits.Count,
                            StartingCoord = (i, j),
                            Number = int.Parse($"{grid[i][j]}"),
                            Length = 1
                        });
                        inDigit = true;
                    }
                    else
                    {
                        digits.Last().Number = int.Parse($"{digits.Last().Number}{grid[i][j]}");
                        digits.Last().Length++;
                    }
                }
                else if (grid[i][j] == '*')
                {
                    gears.Add((i, j));
                    inDigit = false;
                }
                else
                {
                    inDigit = false;
                }
            }
        }

        // Process Gears
        var result = gears.Aggregate(0, (total, gear) =>
        {
            List<Digit> checks = new List<Digit>();
            foreach (var checkCoord in CoordChecks)
            {
                int x = gear.Item1 + checkCoord.Item1;
                int y = gear.Item2 + checkCoord.Item2;
                char c = grid[x][y];

                if (char.IsDigit(c) && !checks.Where(d => d.ID == Digit.FindDigit(digits, (x, y)).ID).Any())
                {
                    checks.Add(Digit.FindDigit(digits, (x, y)));
                }
            }

            return total + (checks.Count == 2 ? checks[0].Number * checks[1].Number : 0);
        });

        Console.WriteLine($"Result: [{result}]");
    }

    class Digit
    {
        public int ID { get; set; }
        public (int, int) StartingCoord { get; set; }
        public int Number { get; set; }
        public int Length { get; set; }

        public static Digit FindDigit(List<Digit> digits, (int, int) coord)
        {
            foreach (Digit digit in digits)
            {
                if (digit.StartingCoord.Item1 == coord.Item1)
                {
                    if (coord.Item2 >= digit.StartingCoord.Item2 && coord.Item2 < digit.StartingCoord.Item2 + digit.Length)
                    {
                        return digit;
                    }
                }
            }

            return null;
        }
    }
}
