using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day02;

public class DayTwoPartOneCode
{
    public void Main(string path)
    {
        using var fileIn = new StreamReader(path);
        string data = fileIn.ReadToEnd();

        Dictionary<string, int> limits = new Dictionary<string, int>()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };

        var games = data.Split('\n');

        int sum = 0;

        foreach (var game in games)
        {
            var info = game.Split(":");
            var ID = int.Parse(info[0].Replace("Game", ""));
            var rounds = info[1].Split(";");

            var passedRound = true;

            foreach (var round in rounds)
            {
                var colors = round.Split(',');

                var passedAllColorsCheck = true;

                foreach (var color in colors)
                {
                    var num = int.Parse(color.Trim().Split(' ')[0]);
                    var _color = color.Trim().Split(' ')[1];

                    if (num > limits[_color])
                        passedAllColorsCheck = false;
                }

                if (!passedAllColorsCheck)
                    passedRound = false;
            }

            if (passedRound)
                sum += ID;
        }

        Console.WriteLine(sum);
    }
}
