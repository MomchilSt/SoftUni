using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var resources = new Dictionary<string, int>();

        while (true)
        {

            string input = Console.ReadLine();

            if (input == "stop")
            {

                break;
            }

            int value = int.Parse(Console.ReadLine());

            if (resources.ContainsKey(input) == false)
            {
                resources.Add(input, value);
            }
            else
            {
                int summ = 0;
                var founded = resources.TryGetValue(input, out summ);
                resources[input] = summ + value;

            }

        }
        foreach (var kvp in resources)
        {
            Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
        }
    }
}