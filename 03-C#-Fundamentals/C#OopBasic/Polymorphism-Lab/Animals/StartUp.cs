﻿using System;

namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            Animal cat = new Cat("Pesho", "Whiskas");
            Animal dog = new Cat("Gosho", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
