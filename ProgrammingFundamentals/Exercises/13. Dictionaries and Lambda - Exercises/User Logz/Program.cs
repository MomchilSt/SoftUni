using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var userIps = new SortedDictionary<string, Dictionary<string, int>>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "end")
            {
                break;
            }

            string[] tokens = input.Split();
            string ip = tokens[0].Split('=')[1];
            string user = tokens[2].Split('=')[1];

            if (userIps.ContainsKey(user) == false)
            {
                userIps[user] = new Dictionary<string, int>();
            }

            if (userIps[user].ContainsKey(ip) == false)
            {
                userIps[user][ip] = 0;
            }

            userIps[user][ip]++;
        }

        foreach (var item in userIps)
        {
            Console.WriteLine($"{item.Key}: ");
            Console.WriteLine(string.Join(", ", item.Value.Select(x => $"{x.Key} => {x.Value}")) + ".");
        }
    }
}
