using System;
using System.Linq;
using System.Text.RegularExpressions;

class MatchPhoneNumber
{
    static void Main()
    {
        string phones = Console.ReadLine();
        string pattern = @"\+359([\- ])2\1\d{3}\1\d{4}\b";

        MatchCollection matches = Regex
            .Matches(phones, pattern);

        string[] validPhones = matches
            .Cast<Match>()
            .Select(a => a.Value.Trim())
            .ToArray();

        Console.WriteLine(string.Join(", ", validPhones));
    }
}
