using MilitaryElit.Contracts;
using MilitaryElit.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElit.Models
{
    public abstract class SpecialisedSoldier : Private , ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string first, string last, decimal salary, Corps corps) 
            : base(id, first, last, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; set; }
    }
}
