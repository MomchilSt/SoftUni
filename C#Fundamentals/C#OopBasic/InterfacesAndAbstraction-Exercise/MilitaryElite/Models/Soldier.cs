using MilitaryElit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElit.Models
{
    public abstract class Soldier : ISoldier
    {
        private int id;
        private string firstName;
        private string lastName;

        public Soldier(int id, string first, string last)
        {
            this.Id = id;
            this.FirstName = first;
            this.LastName = last;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public string FirstName { get => firstName; private set => firstName = value; }
        public string LastName { get => lastName;private set => lastName = value; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} ";
        }
    }
}
