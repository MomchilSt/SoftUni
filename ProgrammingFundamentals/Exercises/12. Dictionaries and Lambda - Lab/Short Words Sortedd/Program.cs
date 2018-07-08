using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> textInput = Console.ReadLine()
            .Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(x => x.Length < 5)
            .Select(x => x.ToLower())
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        Console.WriteLine(string.Join(", ", textInput));
    }
}