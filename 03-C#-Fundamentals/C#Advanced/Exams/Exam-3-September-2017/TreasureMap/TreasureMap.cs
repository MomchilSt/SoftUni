using System;
using System.Text.RegularExpressions;

class TreasureMap
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var regex = new Regex(@"(!|#)[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*(?<!\d)(?<number>\d{3})-(?<password>\d{6}|\d{4})(?!\d)[^!#]*?(?!\1)(#|!)");


        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            var matches = regex.Matches(input);
            var match = matches[matches.Count / 2];

            Console.WriteLine("Go to str. {0} {1}. Secret pass: {2}.",
match.Groups["street"].Value, match.Groups["number"].Value, match.Groups["password"].Value);
        }
    }
}
