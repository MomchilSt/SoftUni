﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new List<Team>();
            this.SecondaryKitTeams = new List<Team>();
        }

        public int ColorId { get; set; }

        public string Name { get; set; }

        //[InverseProperty("PrimaryKitColor")]
        public ICollection<Team> PrimaryKitTeams { get; set; }

       // [InverseProperty("SecondaryKitColor")]
        public ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
