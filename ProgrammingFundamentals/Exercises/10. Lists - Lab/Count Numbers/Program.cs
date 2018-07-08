using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var numList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
        var numDictionary = new Dictionary<int, int>();
        foreach (var num in numList)
        {
            if (!numDictionary.ContainsKey(num))
            {
                numDictionary.Add(num, 0);
            }
            numDictionary[num]++;
        }
        foreach (var num in numDictionary.OrderBy(n => n.Key))
        {
            Console.WriteLine($"{num.Key} -> {num.Value}");
        }


        //List<int> numbers = Console.ReadLine()
        //    .Split()
        //    .Select(int.Parse)
        //    .ToList();

        //numbers.Sort();
        //int counter = 0;

        //List<int> result = new List<int>();

        //for (int i = 0; i < numbers.Count; i++)
        //{
        //    for (int j = 1; j < numbers.Count - 1; j++)
        //    {
        //        if (numbers[i] == numbers[j])
        //        {
        //            counter++;
        //            i++;
        //        }
        //    }
        //    if (numbers[i] != numbers[i + 1])
        //    {
        //        Console.WriteLine($"{numbers[i]} -> {counter}");
        //    }
        //}
    }
}
