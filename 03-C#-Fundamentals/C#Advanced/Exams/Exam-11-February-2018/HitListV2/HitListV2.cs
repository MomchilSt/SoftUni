using System;
using System.Collections.Generic;
using System.Linq;

class HitListV2
{
    static void Main()
    {
        var book = new Dictionary<string, Dictionary<string, string>>();

        int numReq = int.Parse(Console.ReadLine());

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end transmissions")
            {
                break;
            }

            string[] nameTokens = input.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            string name = nameTokens[0];

            string[] tokens = nameTokens[1].Split(new char[] { ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (book.ContainsKey(name) == false)
            {
                book.Add(name, new Dictionary<string, string>());
            }

            for (int i = 0; i < tokens.Length; i+=2)
            {
                if (book[name].ContainsKey(tokens[i]))
                {
                    book[name].Remove(tokens[i]);
                }

                book[name].Add(tokens[i], tokens[i + 1]);
            }
        }

        string[] killCommand = Console.ReadLine().Split();
        string target = killCommand[1];

        if (book.ContainsKey(target))
        {
            Console.WriteLine($"Info on {target}:");
            int num = 0;

            foreach (var kvp in book[target].OrderBy(x => x.Key))
            {
                num += kvp.Key.Length;
                num += kvp.Value.Length;

                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine($"Info index: {num}");

            if (num >= numReq)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {Math.Abs(numReq - num)} more info.");
            }
        }
    }
}