using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> inputText = Console.ReadLine().Split().Select(x => x.ToLower()).ToList();
        var dict = new Dictionary<string, int>();

        foreach (var text in inputText)
        {
            if (dict.ContainsKey(text))
            {
                dict[text]++;
            }
            else
            {
                dict[text] = 1;
            }
        }

        List<string> result = new List<string>();

        foreach (var text in dict)
        {
            if (text.Value % 2 != 0)
            {
                result.Add(text.Key);
                //Console.Write($"{text.Key}, ");
            }
        }
        Console.WriteLine(string.Join(", ", result));
    }
}
