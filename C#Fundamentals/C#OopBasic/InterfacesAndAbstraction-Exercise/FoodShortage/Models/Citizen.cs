using FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Citizen : IIdentifiable, IBirthdate, IName, IBuyer
    {
        private int age;
        public int Food { get; set; } = 0;

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

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
