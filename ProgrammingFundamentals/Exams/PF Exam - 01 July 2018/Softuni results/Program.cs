using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> contest = new Dictionary<string, int>();
        Dictionary<string, int> languageCount = new Dictionary<string, int>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "exam finished")
            {
                break;
            }

            string[] tokens = input.Split('-');

            if (tokens.Length == 3)
            {
                string name = tokens[0];
                string language = tokens[1];
                int result = int.Parse(tokens[2]);

                if (languageCount.ContainsKey(language) == false)
                {
                    languageCount.Add(language, 1);
                }
                else if (languageCount.ContainsKey(language))
                {
                    languageCount[language]++;
                }

                if (contest.ContainsKey(name) == false)
                {
                    contest.Add(name, result);
                }
                else if (contest.ContainsKey(name))
                {
                    if (contest[name] < result)
                    {
                        contest[name] = result;
                    }
                }
            }
            else if (tokens.Length == 2)
            {
                string name = tokens[0];

                if (contest.ContainsKey(name))
                {
                    contest.Remove(name);
                }
            }
        }
        Console.WriteLine("Results:");
        foreach (var part in contest.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{part.Key} | {part.Value}");
        }
        Console.WriteLine("Submissions:");
        foreach (var lang in languageCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{lang.Key} - {lang.Value}");
        }
    }
}