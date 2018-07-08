using System;
using System.Collections.Generic;
using System.Linq;

class WormsWorldParty
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, long>> scores = new Dictionary<string, Dictionary<string, long>>();

        while (true)
        {
            string[] input = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length == 1 && input[0] == "quit")
            {
                break;
            }

            string wormName = input[0];
            bool hasDublicate = false;
            foreach (var team in scores)
            {
                if (team.Value.ContainsKey(wormName))
                {
                    hasDublicate = true;
                    break;
                }
            }
            if (hasDublicate) { continue; }
            string teamName = input[1];
            int wormScore = int.Parse(input[2]);

            if (!scores.ContainsKey(teamName))
            {
                scores[teamName] = new Dictionary<string, long>();
            }

            if (!scores[teamName].ContainsKey(wormName))
            {
                scores[teamName][wormName] = wormScore;
            }
        }

        scores = scores
            .OrderByDescending(x => x.Value.Values.Sum())
            .ThenByDescending(x => x.Value.Values.Sum() / (double)x.Value.Values.Count)
            .ToDictionary(x => x.Key, x => x.Value);

        for (int i = 0; i < scores.Count; i++)
        {
            var item = scores.ElementAt(i);
            var teamName = item.Key;

            scores[teamName] = scores[teamName]
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        int counter = 0;
        foreach (var team in scores)
        {
            counter++;

            Console.WriteLine($"{counter}. Team: {team.Key} - {team.Value.Values.Sum()}");

            foreach (var worm in team.Value)
            {
                Console.WriteLine($"###{worm.Key} : {worm.Value}");
            }
        }
    }
}