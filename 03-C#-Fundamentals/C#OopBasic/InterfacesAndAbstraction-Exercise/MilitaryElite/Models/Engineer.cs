using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElit.Contracts;
using MilitaryElit.Enums;

namespace MilitaryElit.Models
{
    public class Engineer : SpecialisedSoldier , IEngineer
    {
        public Engineer(int id, string first, string last, decimal salary, Corps corps) 
            : base(id, first, last, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {this.Corps}\nRepairs:{(this.Repairs.Any() ? "\n" : "")}{string.Join("\n",this.Repairs)}";
        }
    }
}
