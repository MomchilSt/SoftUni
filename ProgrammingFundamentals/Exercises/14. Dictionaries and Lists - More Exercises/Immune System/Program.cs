using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        long health = long.Parse(Console.ReadLine());
        long startHealth = health;
        List<string> viruses = new List<string>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                break;
            }

            input.ToCharArray();

            int virusStrenght = 0;
            int timeToDefeat = 0;

            foreach (char symbol in input)
            {
                virusStrenght += symbol;
            }

            virusStrenght /= 3;
            timeToDefeat = virusStrenght * input.Length;

            if (viruses.Contains(input))
            {
                timeToDefeat /= 3;
            }

            viruses.Add(input);

            health -= timeToDefeat;
            var min = timeToDefeat / 60;
            var seconds = timeToDefeat - min * 60;

                Console.WriteLine($"Virus {input}: {virusStrenght} => {timeToDefeat} seconds");
            if (health<=0)
            {
                break;
            }
                Console.WriteLine($"{input} defeated in {min}m {seconds}s.");
                Console.WriteLine($"Remaining health: {health}");

            health += health * 20 / 100;

            if (health > startHealth)
            {
                health = startHealth;
            }

        }
        if (health > 0)
        {
            Console.WriteLine($"Final Health: {health}");

        }
        else
        {
            Console.WriteLine($"Immune System Defeated.");
        }
    }
}
