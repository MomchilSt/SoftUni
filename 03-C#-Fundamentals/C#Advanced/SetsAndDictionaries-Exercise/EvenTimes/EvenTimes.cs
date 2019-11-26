using System;
using System.Collections.Generic;

class EvenTimes
{
    static void Main()
    {
        Dictionary<int, int> evenCounter = new Dictionary<int, int>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());

            if (evenCounter.ContainsKey(input) == false)
            {
                evenCounter.Add(input, 1);
            }
            else
            {
                evenCounter[input]++;
            }
        }

        foreach (var num in evenCounter)
        {
            if (num.Value % 2 == 0)
            {
                Console.WriteLine(num.Key);
                break;
            }
        }
    }
}