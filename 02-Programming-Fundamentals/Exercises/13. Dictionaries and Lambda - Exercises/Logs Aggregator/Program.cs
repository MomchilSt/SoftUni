using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static object dictionary;

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var logs = new SortedDictionary<string, SortedDictionary<string, int>>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            string[] tokens = input.Split();
            string ip = tokens[0];
            string name = tokens[1];
            int time = int.Parse(tokens[2]);

            if (logs.ContainsKey(name) == false)
            {
                logs.Add(name, new SortedDictionary<string, int>());
            }

            if (logs[name].ContainsKey(ip) == false)
            {
                //logs[name].Add(ip, time);
                logs[name][ip] = 0;
            }

            logs[name][ip] += time;
        }

        foreach (var name in logs)
        {
            var sum = name.Value.Values.Sum();

            Console.Write("{0}: {1} ", name.Key, sum);
            Console.WriteLine("[" + "{0}" + "]",
                string.Join(", ", name.Value.Keys));
        }
    }
}
