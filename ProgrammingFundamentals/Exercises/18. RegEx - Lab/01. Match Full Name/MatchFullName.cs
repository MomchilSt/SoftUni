using System;
using System.Text.RegularExpressions;
using System.Linq;
class MatchFullName
{
    static void Main()
    {
        string names = Console.ReadLine();
        string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

        MatchCollection validNames = Regex
            .Matches(names, pattern);

        foreach (var name in validNames)
        {
            Console.Write($"{name} ");
        }
        Console.WriteLine();
    }
}
