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
            if (text == "print")
            {
                Console.WriteLine("["+ string.Join(", ", numbers) + "]");
                break;
            }
            else if (text == "add")          // add : <index> <element> and insert to numbers list.
            {
                int position = int.Parse(tokens[1]);
                int num = int.Parse(tokens[2]);
                numbers.Insert(position, num);
            }
            else if (text == "addMany")      // addMany : <index> <elements with lenght equal to numbers.Cout>  input is placed in new addMany list and then added to numbers.
            {
                int position = int.Parse(tokens[1]);
                List<int> addMany = new List<int>();

                for (int i = 2; i <= tokens.Length - 1; i++)
                {
                    int num = int.Parse(tokens[i]);
                    addMany.Add(num);
                }
                numbers.InsertRange(position, addMany);
            }
            else if (text == "contains")     // contains : <input num> checks if it is contained in numbers list and if is true add 0 else add -1 to new contains list
            {
                int num = int.Parse(tokens[1]);
                if (numbers.Contains(num))
                {
                    Console.WriteLine(numbers.IndexOf(num));
                }
                else
                {
                    Console.WriteLine("-1");
                }
            }
            else if (text == "remove")   // remove : <num input> removes the element at num index
            {
                int num = int.Parse(tokens[1]);
                numbers.RemoveAt(num);
            }
            else if (text == "shift")        // shifts : <count of shifts> shifts all elements to left
            {
                int shifts = int.Parse(tokens[1]);
                shifts %= numbers.Count;
                List<int> firstList = numbers.Take(shifts).ToList();

                numbers = numbers.Skip(shifts).ToList();
                numbers.AddRange(firstList);
            }
            else if (text == "sumPairs")     // sums every two 
            {
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    // numbers[i] = numbers[i] + numbers[i - 1];
                    //numbers.RemoveAt(i - 1);

                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                }
            }
        }
    }
}