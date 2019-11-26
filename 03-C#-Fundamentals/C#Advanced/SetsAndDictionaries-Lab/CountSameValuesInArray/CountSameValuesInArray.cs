using System;
using System.Collections.Generic;
using System.Linq;

class CountSameValuesInArray
{
    static void Main()
    {
        Dictionary<string, int> valuesCouter = new Dictionary<string, int>();

        string[] input = Console.ReadLine()
            .Split();

        for (int i = 0; i < input.Length; i++)
        {
            if (valuesCouter.ContainsKey(input[i]) == false)
            {
                valuesCouter.Add(input[i], 1);
            }
            else
            {
                valuesCouter[input[i]]++;
            }
        }

        foreach (var keyValue in valuesCouter)
        {
            Console.WriteLine($"{keyValue.Key} - {keyValue.Value} times");
        }
    }
}