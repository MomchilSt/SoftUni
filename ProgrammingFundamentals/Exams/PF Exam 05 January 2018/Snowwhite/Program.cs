using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, long>> book = new Dictionary<string, Dictionary<string, long>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Once upon a time")
            {
                break;
            }

            string[] tokens = input.Split(new char[] { ' ', ':', '<', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0].Trim();
            string hatColor = tokens[1].Trim();
            long physics = long.Parse(tokens[2].Trim());

            if (book.ContainsKey(hatColor) && book[hatColor].ContainsKey(name))
            {
                if (book[hatColor][name] < physics)
                {
                    book[hatColor][name] = physics;
                }
            }

            else if (book.ContainsKey(hatColor) == false)
            {
                book.Add(hatColor, new Dictionary<string, long>());

                if (book[hatColor].ContainsKey(name) == false)
                {
                    book[hatColor].Add(name, physics);
                }
            }

            else if (book.ContainsKey(hatColor) && book[hatColor].ContainsKey(name) == false)
            {
                book[hatColor].Add(name, physics);
            }
        }
        foreach (var name in book.OrderByDescending(x => x.Value.Values.Sum()))
        {
            foreach (var color in name.Value.OrderByDescending(x => x.Key))
            {
                Console.WriteLine($"({name.Key}) {color.Key} <-> {color.Value}");
            }
        }
    }
}
