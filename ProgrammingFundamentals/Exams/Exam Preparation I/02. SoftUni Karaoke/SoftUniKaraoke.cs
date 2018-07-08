using System;
using System.Collections.Generic;
using System.Linq;

class SoftUniKaraoke
{
    static void Main()
    {
        string[] candidates = Console.ReadLine()
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < candidates.Length; i++)
        {
            candidates[i] = candidates[i]
                .TrimStart(new char[] { ' ', '\t' })
                .TrimEnd(new char[] { ' ', '\t' });
        }
        string[] songs = Console.ReadLine()
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < songs.Length; i++)
        {
            songs[i] = songs[i]
                .TrimStart(new char[] { ' ', '\t' })
                .TrimEnd(new char[] { ' ', '\t' });
        }

        Dictionary<string, List<string>> persons = new Dictionary<string, List<string>>();
        while (true)
        {
            string[] stage = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < stage.Length; i++)
            {
                stage[i] = stage[i]
                    .TrimStart(new char[] { ' ', '\t' })
                    .TrimEnd(new char[] { ' ', '\t' });
            }

            if (string.Join("", stage) == "dawn")
            {
                break;
            }

            string participant = stage[0];
            string song = stage[1];
            string award = stage[2];

            if (!candidates.Contains(participant) || !songs.Contains(song))
            {
                continue;
            }

            if (persons.ContainsKey(participant))
            {
                persons[participant].Add(award);
            }
            else
            {
                persons[participant] = new List<string> { award };
            }
        }

        for (int i = 0; i < persons.Count; i++)
        {
            string awards = persons.ElementAt(i).Key;

            persons[awards] = persons[awards]
                .Distinct()
                .OrderBy(a => a)
                .ToList();
        }

        persons = persons
            .OrderByDescending(x => x.Value.Count)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

        if (persons.Values.All(x => x.Count == 0))
        {
            Console.WriteLine("No awards");
        }

        foreach (var prs in persons)
        {
            Console.WriteLine($"{prs.Key}: {prs.Value.Count} awards");

            foreach (string award in prs.Value)
            {
                Console.WriteLine($"--{award}");
            }
        }
    }
}
