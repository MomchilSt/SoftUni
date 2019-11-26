using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Regeh
{
    static void Main()
    {
        string pattern = @"\[\w+[^\[\] ]*?<(\d+)REGEH(\d+)>\w+]";
        //\[\w+[^\[\] ]*?<(\d+)REGEH(\d+)>\w+]
        //(\[)\w+[^\[\] ]*?<(?<first>\d+)REGEH(?<second>\d+)>\w+(])

        List<int> indexes = new List<int>();

        string input = Console.ReadLine();

        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);

        int currIndex = 0;
        int lenght = input.Length - 1;

        string result = string.Empty;

        foreach (Match match in matches)
        {
            indexes.Add(int.Parse(match.Groups[1].Value));
            indexes.Add(int.Parse(match.Groups[2].Value));
        
        }

        foreach (var index in indexes)
        {
            currIndex += index;
            var charIndex = currIndex % lenght;
            Console.Write(input[charIndex]);
        }
        Console.WriteLine();
    }
}