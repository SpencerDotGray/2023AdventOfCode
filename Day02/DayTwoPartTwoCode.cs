using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day02;

public class DayTwoPartTwoCode
{
    public void Main(string path)
    {
        using var fileIn = new StreamReader(path);
        string data = fileIn.ReadToEnd();

        var games = data.Split('\n').Select(s => s.Split(':')[1].Trim());

        int sum = 0;

        foreach (var game in games)
        {
            Dictionary<string, int> maxes = new Dictionary<string, int>()
            {
                { "red", 0 },
                { "blue", 0},
                { "green", 0 }
            };

            var rounds = game.Split(";");

            foreach (var round in rounds)
            {
                var colors = round.Split(',');

                foreach (var color in colors)
                {
                    var num = int.Parse(color.Trim().Split(' ')[0]);
                    var _color = color.Trim().Split(' ')[1];

                    if (maxes[_color] < num)
                        maxes[_color] = num;
                }
            }

            sum += maxes.Keys.Aggregate(1, (prod, next) => prod * maxes[next]);
        }

        Console.WriteLine(sum);
    }
}
