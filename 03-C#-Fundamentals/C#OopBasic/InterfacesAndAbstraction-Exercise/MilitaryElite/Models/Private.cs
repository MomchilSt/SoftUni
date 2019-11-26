using MilitaryElit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElit.Models
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public Private(int id, string first, string last, decimal salary)
            : base(id,first,last)
        {
            this.Salary = salary;
        }

        public decimal Salary { get => salary;private set => salary = value; }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {this.Salary:f2}";
        }
    }
}
