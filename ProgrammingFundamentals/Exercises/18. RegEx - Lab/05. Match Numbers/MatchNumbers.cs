using System;
using System.Text.RegularExpressions;

class MatchNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

        MatchCollection validNums = Regex.Matches(input, pattern);

        foreach (Match num in validNums)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();
    }
}
