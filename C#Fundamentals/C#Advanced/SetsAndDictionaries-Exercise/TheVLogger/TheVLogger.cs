using System;
using System.Collections.Generic;
using System.Linq;

class TheVLogger
{
    static void Main()
    {
        var vloggers = new Dictionary<string, Dictionary<string, List<string>>>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Statistics")
            {
                break;
            }

            string[] tokens = input.Split();
            string action = tokens[1];

            if (action == "joined")
            {
                string name = tokens[0];

                if (vloggers.ContainsKey(name) == false)
                {
                    vloggers.Add(name, new Dictionary<string, List<string>>());
                    vloggers[name].Add("followers", new List<string>());
                    vloggers[name].Add("following", new List<string>());
                }
            }
            else
            {
                string firstVlogger = tokens[0];
                string secondVlogger = tokens[2];

                if (firstVlogger == secondVlogger)
                {
                    continue;
                }
                if (vloggers.ContainsKey(firstVlogger) == false || vloggers.ContainsKey(secondVlogger) == false)
                {
                    continue;
                }
                if (vloggers[firstVlogger]["following"].Contains(secondVlogger) == false)
                {
                    vloggers[secondVlogger]["followers"].Add(firstVlogger);
                    vloggers[firstVlogger]["following"].Add(secondVlogger);
                }
            }

        }

        Console.WriteLine($"The V-Logger has a total of {vloggers.Count()} vloggers in its logs.");

        int counter = 1;

        foreach (var person in vloggers.OrderByDescending(x => x.Value["followers"].Count()).ThenBy(x => x.Value["following"].Count()))
        {
            var name = person.Key;
            var followers = vloggers[name]["followers"].Count;
            var following = vloggers[name]["following"].Count;

            Console.WriteLine($"{counter}. {name} : {followers} followers, {following} following");

            if (counter == 1)
            {
                foreach (var current in person.Value["followers"].OrderBy(x => x))
                {
                    Console.WriteLine($"*  {current}");
                }
            }
            counter++;
        }
    }
}
