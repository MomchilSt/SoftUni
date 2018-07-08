using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        while (true)
        {
            string[] tokens = Console.ReadLine().Split();
            string text = (tokens[0]);

            if (text == "Odd")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] % 2 != 0)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                break;
            }

            if (text == "Even")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                break;
            }

            if (text == "Delete")
            {
                numbers.RemoveAll(x => x == int.Parse(tokens[1])); 
            }

            if (text == "Insert")
            {
                int num = int.Parse(tokens[1]);
                int position = int.Parse(tokens[2]);
                numbers.Insert(position, num);
            }
        }
    }
}
