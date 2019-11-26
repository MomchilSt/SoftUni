using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * 0.25;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"Owl does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
