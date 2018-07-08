using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<decimal> numbers = Console.ReadLine().Split().Select(decimal.Parse).ToList();

        int counter = 0;

        while (true)
        {
            if (numbers.Count <= counter)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }
            else if ((counter + 1) >= numbers.Count)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }
            else if (numbers[counter] == numbers[counter + 1])
            {
                numbers[counter] = numbers[counter] + numbers[counter + 1];
                numbers.RemoveAt(counter + 1);
                counter=0;
            }
            else
            {
                counter++;
            }
        }
    }
}