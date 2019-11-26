using System;

class Program
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());

        int cheese = 500;
        int tomatoSauce = 150;
        int salami = 600;
        int pepper = 50;

        int total = 0;

        for (int i = 0; i < num; i++)
        {
            string food = Console.ReadLine().ToLower();

            if (food == "cheese")
            {
                total += 500;
            }
            else if (food == "tomato sauce")
            {
                total += 150;
            }
            else if (food == "salami")
            {
                total += 600;
            }
            else if (food == "pepper")
            {
                total += 50;
            }
        }

        Console.WriteLine($"Total calories: {total}");
    }
}
