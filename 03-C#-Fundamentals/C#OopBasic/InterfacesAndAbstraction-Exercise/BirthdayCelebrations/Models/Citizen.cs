using BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IIdentifiable, IBirthdate, IName
    {
        private int age;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public string Name { get; private set; }
    }
}
