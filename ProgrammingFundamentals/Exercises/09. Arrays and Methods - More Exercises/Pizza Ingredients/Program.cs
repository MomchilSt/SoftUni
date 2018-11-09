using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] ingredients = Console.ReadLine()
            .Split();
        List<string> pizza = new List<string>();

        int n = int.Parse(Console.ReadLine());

        int counter = 0;

        for (int i = 0; i < ingredients.Length && counter < 10; i++)
        {
            if (ingredients[i].Length == n)
            {
                counter++;
                Console.WriteLine($"Adding {ingredients[i]}.");
                pizza.Add(ingredients[i]);
            }
        }

        Console.WriteLine($"Made pizza with total of {counter} ingredients.");
        Console.WriteLine("The ingredients are: " + string.Join(", ", pizza) + ".");
    }
}
/*        string[] ingredients = Console.ReadLine()
            .Split();
        int n = int.Parse(Console.ReadLine());

        int counter = 0;

        for (int i = 0; i < ingredients.Length; i++)
        {
            if (ingredients[i].Length == n)
            {
                counter++;
                Console.WriteLine($"Adding {ingredients[i]}.");
            }

            if (i == ingredients.Length - 1)
            {
                Console.WriteLine($"Made pizza with total of {counter} ingredients.");
                Console.Write("The ingredients are: ");

                for (int j = 0; j < ingredients.Length; j++)
                {
                    if (ingredients[j].Length == n && counter == 1)
                    {
                        Console.Write($"{ingredients[j]}.");
                    }

                    else if (ingredients[j].Length == n)
                    {
                        Console.Write($"{ingredients[j]}, ");
                        counter--;
                    }
                }
            }
        }
        Console.WriteLine();*/
