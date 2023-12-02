using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace _2023AdventOfCode.Day01;

public class DayOnePartOneCode
{
    public void Main()
    {
        Console.WriteLine(
            new StreamReader(@"E:\Dev\2023AdventOfCode\Day01\part_1_input.txt").ReadToEnd().Split('\n').ToList().Select(
                s => String.Join("",
                    s.ToCharArray().Where(c => Char.IsDigit(c)).Where((c, i) => i == 0 || i == (s.ToCharArray().Where(c => Char.IsDigit(c)).Count() - 1))
                )
            ).Aggregate(0, (prod, next) => prod + (next.Length == 1 ? int.Parse($"{next}{next}") : int.Parse(next)))
        );
    }
}
