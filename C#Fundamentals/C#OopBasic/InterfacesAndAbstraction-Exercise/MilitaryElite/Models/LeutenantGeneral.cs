using MilitaryElit.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElit.Models
{
    public class LeutenantGeneral : Private, ILieutenantGeneral
    {
        public LeutenantGeneral(int id, string first, string last, decimal salary) 
            : base(id, first, last, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates
        {
            get;
            set;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nPrivates:{(this.Privates.Any() ? "\n" : "")}{string.Join("\n  ", Privates)}";
        }
    }
}
