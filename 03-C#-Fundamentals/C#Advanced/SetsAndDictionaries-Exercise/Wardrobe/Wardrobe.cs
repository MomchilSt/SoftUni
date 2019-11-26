using System;
using System.Collections.Generic;

class Wardrobe
{
    static void Main()
    {
        var clothes = new Dictionary<string, Dictionary<string, int>>();

        int n = int.Parse(Console.ReadLine());

        for (int m1 = 0; m1 < n; m1++)
        {
            string[] input = Console.ReadLine()
                .Split( " -> ");

            string color = input[0];
            string[] tokens = input[1].Split(',');

            if (clothes.ContainsKey(color) == false)
            {
                clothes.Add(color, new Dictionary<string, int>());
            }

            for (int m2 = 0; m2 < tokens.Length; m2++)
            {
                if (clothes[color].ContainsKey(tokens[m2]) == false)
                {
                    clothes[color].Add(tokens[m2], 0);
                }
                    clothes[color][tokens[m2]]++;
            }
        }

        string[] search = Console.ReadLine().Split(' ');
        string searchColor = search[0];
        string searchItem = search[1];

        foreach (var colar in clothes) 
        {
            Console.WriteLine($"{colar.Key} clothes:");

            foreach (var type in colar.Value)
            {
                if (type.Key == searchItem && colar.Key == searchColor)
                {
                    Console.WriteLine($"* {type.Key} - {type.Value} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {type.Key} - {type.Value}");
                }
            }
        }
    }
}