using BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IName, IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Birthdate { get; private set; }

        public string Name { get; private set; }
    }
}
