using System;
using System.Collections.Generic;
using System.Linq;

class Tagram
{
    static void Main()
    {
        var keeper = new Dictionary<string, Dictionary<string, int>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                break;
            }

            var tokens = input.Split(new string[] { "->", " " }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens[0] == "ban")
            {
                string removeName = tokens[1].Trim();
                if (keeper.ContainsKey(removeName))
                {
                    keeper.Remove(removeName);
                }
                continue;
            }

            string name = tokens[0];
            string tag = tokens[1];
            int likes = int.Parse(tokens[2]);

            if (keeper.ContainsKey(name) == false)
            {
                keeper.Add(name, new Dictionary<string, int>());
            }

            if (keeper[name].ContainsKey(tag) == false)
            {
                keeper[name].Add(tag, likes);
                continue;
            }

            keeper[name][tag] += likes;
        }

        foreach (var name in keeper.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Count))
        {
            Console.WriteLine(name.Key);

            foreach (var tag in name.Value)
            {
                Console.WriteLine($"- {tag.Key}: {tag.Value}");
            }
        }
    }
}