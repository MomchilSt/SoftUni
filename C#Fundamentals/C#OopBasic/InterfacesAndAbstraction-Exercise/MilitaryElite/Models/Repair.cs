using MilitaryElit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElit.Models
{
    public class Repair : IRepair
    {
        private string partName;
        private int hoursWorked;

        public Repair(string partName, int hw)
        {
            this.PartName = partName;
            this.HoursWorked = hw;
        }

        public string PartName { get => partName; private set => partName = value; }
        public int HoursWorked { get => hoursWorked; private set => hoursWorked = value; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
