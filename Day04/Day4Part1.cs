using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day04;

public class Day4Part1
{
    public void Main(string path)
    {
        string data = new StreamReader(path).ReadToEnd();
        var cards = data.Split('\n');

        var result = cards.Aggregate(0, (total, card) =>
        {
            card = card.Split(':')[1].Trim();

            var winning = card.Split('|')[0].Trim().Replace("  ", " ").Split(' ').Select(s => int.Parse(s.Trim())).ToList();
            var selected = card.Split('|')[1].Trim().Replace("  ", " ").Split(' ').Select(s => int.Parse(s.Trim())).ToList();

            var points = MathF.Floor(selected.Aggregate(0.5f, (total, number) => total * (winning.Contains(number) ? 2 : 1)));

            return total + Convert.ToInt32(points);
        });

        Console.WriteLine($"Result: [{result}]");
    }
}
