using System;

class Program
{
    static void Main()
    {
        int counter = 0;

        for (int i = 0; i < 20; i++)
        {
            string ingredient = Console.ReadLine();
            if (ingredient == "Bake!")
            {
                break;
            }
            counter++;
            Console.WriteLine($"Adding ingredient {ingredient}.");
        }
        Console.WriteLine($"Preparing cake with {counter} ingredients.");
    }
}
