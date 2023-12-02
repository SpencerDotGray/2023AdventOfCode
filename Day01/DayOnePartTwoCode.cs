using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day01;

public class DayOnePartTwoCode
{
    public void Main()
    {
        Dictionary<string, string> replaceDigits = new Dictionary<string, string>() 
        {
            { "one", "o1e" },
            { "two", "t2o" },
            { "three", "t3e" },
            { "four", "f4r" },
            { "five", "f5e" },
            { "six", "s6x" },
            { "seven", "s7n" },
            { "eight", "e8t" },
            { "nine", "n9e" },
        };

        var codes = new StreamReader(@"E:\Dev\2023AdventOfCode\Day01\part_2_input.txt").ReadToEnd().Split('\n').ToList();
        int sum = 0;

        foreach (var code in codes)
        {
            var digitsOnly = replaceDigits.Keys
                .Aggregate(code, (prod, next) => prod.Replace(next, replaceDigits[next]))
                .Where(c => Char.IsDigit(c));

            sum += int.Parse($"{digitsOnly.First()}{digitsOnly.Last()}");
        }

        Console.WriteLine(sum);
    }
}
