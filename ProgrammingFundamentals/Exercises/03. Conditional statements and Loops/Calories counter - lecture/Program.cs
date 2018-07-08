using System;

class Program
{
    static void Main()
    {
        int ingredients = int.Parse(Console.ReadLine());

        int total = 0;
        int cheese = 500;
        int tomatoSauce = 150;
        int salami = 600;
        int pepper = 50;

        for (int i = 0; i < ingredients; i++)
        {
            string addToPizza = Console.ReadLine().ToLower();

            if (addToPizza == "cheese")
            {
                total += cheese;
            }
            else if (addToPizza == "tomato sauce")
            {
                total += tomatoSauce;
            }
            else if (addToPizza == "salami")
            {
                total += salami;
            }
            else if (addToPizza == "pepper")
            {
                total += pepper;
            }
        }

        Console.WriteLine("Total calories: {0}", total);
    }
}
