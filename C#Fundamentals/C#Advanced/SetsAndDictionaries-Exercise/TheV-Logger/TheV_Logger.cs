using System;
using System.Collections.Generic;
using System.Linq;

class TheV_Logger
{
    static void Main()
    {
        var vloggers = new Dictionary<string, List<int>>();
        var followersNames = new Dictionary<string, List<string>>();

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
                    vloggers.Add(name, new List<int>());
                }
                    vloggers[name].Add(0);
                    vloggers[name].Add(0);
            }
            else
            {
                string firstVl = tokens[0];
                string secondVl = tokens[2];

                if (vloggers.ContainsKey(firstVl) == true && vloggers.ContainsKey(secondVl) == true)
                {
                    bool isDiff = firstVl != secondVl;

                    if (followersNames.ContainsKey(secondVl) == false && isDiff == true)
                    {
                        followersNames.Add(secondVl, new List<string>());
                    }

                    followersNames[secondVl].Add(firstVl);

                    vloggers[secondVl][0]++;
                    vloggers[firstVl][1]++;
                }
            }
        }

        Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
        int counter = 1;

        foreach (var item in vloggers.OrderByDescending(x => x.Value.Count))
        {
            Console.WriteLine($"{counter}. {item.Key} : {item.Value[0]} followers, {item.Value[1]} following");

            if (counter == 1)
            {
                foreach (var followers in followersNames)
                {
                    if (item.Key == followers.Key)
                    {
                        for (int i = 0; i < followers.Value.Count; i++)
                        {
                            Console.WriteLine($"* {followers.Value[i]}");
                        }
                    }
                }
            }

            counter++;

        }
    }
}
