using System;
using System.Collections.Generic;
using System.Linq;

class CountUppercaseWords
{
    static void Main()
    {
        List<string> list = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Console.WriteLine(string.Join(Environment.NewLine, list
            .Where(w => char.IsUpper(w[0]))));
    }
}