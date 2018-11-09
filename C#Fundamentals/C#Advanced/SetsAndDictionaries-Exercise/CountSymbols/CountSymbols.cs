using System;
using System.Collections.Generic;
using System.Linq;

class CountSymbols
{
    static void Main()
    {
        Dictionary<char, int> charCounter = new Dictionary<char, int>();

        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            if (charCounter.ContainsKey(input[i]) == false)
            {
                charCounter.Add(input[i], 1);
            }
            else
            {
                charCounter[input[i]]++;
            }
        }

        foreach (var symbol in charCounter.OrderBy(x=> x.Key))
        {
            Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
        }
    }
}
