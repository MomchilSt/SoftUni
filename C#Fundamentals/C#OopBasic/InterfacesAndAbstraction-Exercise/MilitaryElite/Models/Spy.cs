using MilitaryElit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElit.Models
{
    public class Spy : Soldier, ISpy
    {
        private int codeNumber;

        public Spy(int id, string first, string last, int codeNumber) 
            : base(id, first, last)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get => codeNumber; private set => codeNumber = value; }

        public override string ToString()
        {
            return base.ToString() + $"\nCode Number: {this.CodeNumber}";
        }
    }
}
