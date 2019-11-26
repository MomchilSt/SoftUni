using System;
using System.Text.RegularExpressions;

class MatchHexadecimalNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"\b(?:0x)?[0-9A-F]+\b";

        MatchCollection hexNums = Regex
            .Matches(input, pattern);

        foreach (var hex in hexNums)
        {
            Console.Write($"{hex} ");
        }
        Console.WriteLine();
    }
}
