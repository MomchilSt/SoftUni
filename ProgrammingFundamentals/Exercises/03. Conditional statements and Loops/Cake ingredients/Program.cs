using System;

class Program
{
    static void Main()
    {
        int counter = 0;

        for (int i = 0; i <= 20; i++)
        {
            counter++;
            string ingredient = Console.ReadLine();

            if (ingredient == "Bake!")
            {
                Console.WriteLine($"Preparing cake with {counter - 1} ingredients.");
                return;
            }
            Console.WriteLine($"Adding ingredient {ingredient}.");


        }
    }
}
