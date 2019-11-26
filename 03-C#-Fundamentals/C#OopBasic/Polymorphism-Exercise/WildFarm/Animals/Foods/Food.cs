using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Foods.Contracts;

namespace WildFarm.Animals.Foods
{
    public abstract class Food : IFood
    {
        private int quantity;

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
