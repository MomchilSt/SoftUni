namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";

		private readonly IStage stage;
        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory = new InstrumentFactory();

		public FestivalController(IStage stage,
            ISetFactory setFactory,
            IInstrumentFactory instrumentFactory)
		{
			this.stage = stage;
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
		}
        //checked
		public string RegisterSet(string[] args)
		{
            string name = args[0];
            string type = args[1];

            var set = setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            string result = $"Registered {type} set";

            return result;
        }
        //checked
		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var instrumentNames = args.Skip(2).ToArray();

			var instruments = instrumentNames
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

            var performer = new Performer(name, age);

			foreach (var instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

            string result = $"Registered performer {performer.Name}";

            return result;
		}
        //checked
		public string RegisterSong(string[] args)
		{
            string name = args[0];
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, null);

            ISong song = new Song(name, duration);
            stage.AddSong(song);

            string result = $"Registered song {name} ({duration:mm\\:ss})";
            return result;
		}
        //checked
        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            string result = $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
            return result;
        }
        //checked
        public string AddPerformerToSet(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

            string result = $"Added {performer.Name} to {set.Name}";

            return result;
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			string result = $"Repaired {instrumentsToRepair.Length} instruments";
            return result;
		}

        private string GetRightFormat(TimeSpan timeSpan)
        {
            int minutes = timeSpan.Hours * 60 + timeSpan.Minutes;
            int seconds = timeSpan.Seconds;

            string result = $"{minutes:d2}:{seconds:d2}";
            return result;
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {GetRightFormat(totalFestivalLength)}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                result += ($"--{set.Name} ({GetRightFormat(set.ActualDuration)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({GetRightFormat(song.Duration)})") + "\n";
                    }
                }
            }

            return result.ToString();
        }
    }
}