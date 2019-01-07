using OnlineRadioDatabase.Exceptions;
using System;

namespace OnlineRadioDatabase
{
    public class StartUp
    {
        public static void Main()
        {
            Collection collection = new Collection();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(';');

                try
                {
                    string artist = input[0];
                    string songName = input[1];


                    int minutes;
                    int seconds;
                    string[] duration = input[2].Split(':');
                    if (duration.Length != 2 || int.TryParse(duration[0], out minutes) == false|| int.TryParse(duration[1], out seconds) == false)
                    {
                        throw new InvalidSongLengthException();
                    }

                    int.TryParse(duration[0], out minutes);
                    int.TryParse(duration[1], out seconds);

                    Song song = new Song(artist, songName, minutes, seconds);

                    Console.WriteLine(collection.AddSong(song));
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(collection);
        }
    }
}
