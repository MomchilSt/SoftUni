using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();

        string[] texts = Regex
            .Split(input, @"[0-9]+")
            .Where(x => x != string.Empty)
            .Select(x => x.ToUpper())
            .ToArray();
        int[] nums = Regex.Matches(input, @"[0-9]+")
            .Cast<Match>()
            .Select(x => x.Value)
            .Where(x => x != string.Empty)
            .Select(x => int.Parse(x))
            .ToArray();

        StringBuilder message = new StringBuilder("");
        List<int> uniqueSymbs = new List<int>();

        for (int i = 0; i < texts.Length; i++)
        {
            foreach (char symb in texts[i])
            {
                if (!uniqueSymbs.Contains(symb) && nums[i] != 0)
                {
                    uniqueSymbs.Add(symb);
                }
            }

            for (int j = 0; j < nums[i]; j++)
            {
                message.Append(texts[i]);
            }
        }

        Console.WriteLine($"Unique symbols used: {uniqueSymbs.Count}");
        Console.WriteLine(message);
    }
}
