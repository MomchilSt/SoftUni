using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> textNumbers = Console.ReadLine()
            .Split('|')
            .Reverse()
            .ToList();

        foreach (var text in textNumbers)
        {
            text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            Console.Write(text + " ");
        }
        Console.WriteLine();
    }
}
