using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElit.Contracts;
using MilitaryElit.Enums;

namespace MilitaryElit.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string first, string last, decimal salary, Corps corps) 
            : base(id, first, last, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {this.Corps}\nMissions:{(this.Missions.Any() ? "\n  " : "")}{string.Join("\n  ", this.Missions)}";
        }
    }
}
