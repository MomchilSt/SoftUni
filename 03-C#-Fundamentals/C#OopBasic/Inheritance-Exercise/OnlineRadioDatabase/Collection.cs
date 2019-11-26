using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRadioDatabase
{
    public class Collection
    {
        private List<Song> songs = new List<Song>();

        public string AddSong(Song song)
        {
            songs.Add(song);

            return "Song added.";
        }

        public override string ToString()
        {
            int totalSeconds = songs.Select(x => x.GetSeconds()).Sum();
            var builder = new StringBuilder();
            builder.AppendLine($"Songs added: {songs.Count}");
            builder.Append($"Playlist length: {totalSeconds / 3600}h {totalSeconds / 60 % 60}m {totalSeconds % 60}s");

            return builder.ToString();
        }
    }
}
