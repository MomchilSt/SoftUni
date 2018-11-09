using System;
using System.Collections.Generic;
using System.Linq;

class Ranking
{
    static void Main()
    {
         var contestPases = new Dictionary<string, string>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "end of contests")
            {
                break;
            }

            string[] tokens = input.Split(':');

            string contest = tokens[0];
            string password = tokens[1];

            if (contestPases.ContainsKey(contest) == false)
            {
                contestPases.Add(contest, password);
            }
        }

        var grades = new Dictionary<string, Dictionary<string, int>>();
        string bestCand = string.Empty;
        int bestGrade = 0;

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "end of submissions")
            {
                break;
            }

            string[] tokens = input.Split("=>");

            string contest = tokens[0];
            string password = tokens[1];
            string name = tokens[2];
            int points = int.Parse(tokens[3]);

            if (contestPases.ContainsKey(contest) == false)
            {
                continue;
            }
            if (contestPases.ContainsValue(password) == false)
            {
                continue;
            }

            if (grades.ContainsKey(name) == false)
            {
                grades.Add(name, new Dictionary<string, int>());
            }
            if (grades.ContainsKey(name) && grades[name].ContainsKey(contest) == false)
            {
                grades[name].Add(contest, points);
            }

            if (grades.ContainsKey(name) && grades[name].ContainsKey(contest))
            {
                int oldPoints = grades[name][contest];

                if (oldPoints < points)
                {
                    grades[name][contest] = points;
                }
            }

            bestGrade = grades[name].Values.Sum();
        }

        foreach (var cand in grades.OrderByDescending(x => x.Value.Values.Sum()))
        {
            bestCand = cand.Key;
            break;
        }

        Console.WriteLine($"Best candidate is {bestCand} with total {bestGrade} points.");
        Console.WriteLine("Ranking: ");

        foreach (var cand in grades.OrderBy(x => x.Key))
        {
            Console.WriteLine(cand.Key);

            foreach (var current in cand.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {current.Key} -> {current.Value}");
            }
        }
    }
}