using System;
using System.Collections.Generic;
using System.Linq;

class MovieTime
{
    static void Main()
    {
        string genre = Console.ReadLine();
        string duration = Console.ReadLine();

        var imdb = new Dictionary<string, Dictionary<string, TimeSpan>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "POPCORN!")
            {
                break;
            }

            string[] tokens = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            string movieName = tokens[0];
            string currGenre = tokens[1];
            TimeSpan currDuration = TimeSpan.Parse(tokens[2]);

            if (imdb.ContainsKey(currGenre) == false)
            {
                imdb.Add(currGenre, new Dictionary<string, TimeSpan>());
            }

            imdb[currGenre].Add(movieName, currDuration);
        }

        if (duration == "Short")
        {
            imdb[genre] = imdb[genre].OrderBy(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);
        }
        else if (duration == "Long")
        {
            imdb[genre] = imdb[genre].OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, y => y.Value);
        }

        foreach (var movie in imdb[genre])
        {
            Console.WriteLine(movie.Key);
            string input = Console.ReadLine();

            if (input == "Yes")
            {
                var totalSeconds = imdb.Values.Sum(x => x.Values.Sum(c => c.TotalSeconds));
                string timeSpan = TimeSpan.FromSeconds(totalSeconds).ToString(@"hh\:mm\:ss");

                Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                Console.WriteLine($"Total Playlist Duration: {timeSpan}");
                return;
            }
        }
    }
}