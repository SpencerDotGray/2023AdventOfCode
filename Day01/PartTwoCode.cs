using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day01;

public class PartTwoCode
{
    public void Main()
    {
        Dictionary<string, string> replaceDigits = new Dictionary<string, string>() 
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" },
        };

        var codes = new StreamReader(@"E:\Dev\2023AdventOfCode\Day01\part_2_input.txt").ReadToEnd().Split('\n').ToList();
        int sum = 0;

        foreach (var code in codes)
        {
            var digitsOnly = replaceDigits.Keys
                .Aggregate(code, (prod, next) => prod.Replace(next, replaceDigits[next]))
                .Where(c => Char.IsDigit(c));

            Console.WriteLine($"{code}");
            Console.WriteLine($"{digitsOnly.First()}{digitsOnly.Last()}");

            sum += int.Parse($"{digitsOnly.First()}{digitsOnly.Last()}");
        }

        Console.WriteLine(sum);
    }
}
