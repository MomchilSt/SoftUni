using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class FootballLeague
{
    static void Main()
    {
        string key = Regex.Escape(Console.ReadLine());

        Dictionary<string, int[]> teams = new Dictionary<string, int[]>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "final") { break; }
            string pattern = $@"{key}(?<firstTeamName>\w*){key}.*{key}(?<secondTeamName>\w*){key}.*[^\d](?<firstTeamGoals>\d+):(?<secondTeamGoals>\d+)";
            Match match = Regex.Match(input, pattern);

            string firstTeamName = new string(match.Groups["firstTeamName"].ToString().ToUpper().Reverse().ToArray());
            string secondTeamName = new string(match.Groups["secondTeamName"].ToString().ToUpper().Reverse().ToArray());
            int firstTeamGoals = int.Parse(match.Groups["firstTeamGoals"].ToString());
            int secondTeamGoals = int.Parse(match.Groups["secondTeamGoals"].ToString());
            int firstTeamPoints = 0;
            int secondTeamPoints = 0;

            if (firstTeamGoals > secondTeamGoals)
            {
                firstTeamPoints += 3;
            }
            else if (secondTeamGoals > firstTeamGoals)
            {
                secondTeamPoints += 3;
            }
            else if (firstTeamGoals == secondTeamGoals)
            {
                firstTeamPoints++;
                secondTeamPoints++;
            }

            if (!teams.ContainsKey(firstTeamName))
            {
                teams[firstTeamName] = new int[] { 0, 0 };
            }
            teams[firstTeamName][0] += firstTeamGoals;
            teams[firstTeamName][1] += firstTeamPoints;

            if (!teams.ContainsKey(secondTeamName))
            {
                teams[secondTeamName] = new int[] { 0, 0 };
            }
            teams[secondTeamName][0] += secondTeamGoals;
            teams[secondTeamName][1] += secondTeamPoints;
        }

        teams = teams.OrderByDescending(x => x.Value[1])
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, y => y.Value);

        int counter = 0;
        Console.WriteLine("League standings:");
        foreach (KeyValuePair<string, int[]> team in teams)
        {
            counter++;
            Console.WriteLine($"{counter}. {team.Key} {team.Value[1]}");
        }

        teams = teams.OrderByDescending(x => x.Value[0])
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, y => y.Value);

        counter = 0;
        Console.WriteLine("Top 3 scored goals:");
        foreach (KeyValuePair<string, int[]> team in teams)
        {
            counter++;
            if (counter > 3) { break; }

            Console.WriteLine($"- {team.Key} -> {team.Value[0]}");
        }
    }
}
