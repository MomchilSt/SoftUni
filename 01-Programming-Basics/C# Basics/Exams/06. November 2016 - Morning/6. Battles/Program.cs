using System;

namespace _6.Battles
{
    class Program
    {
        static void Main()
        {
            int pokemons1 = int.Parse(Console.ReadLine());
            int pokemons2 = int.Parse(Console.ReadLine());
            int maxBattles = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i1 = 1; i1 <= pokemons1; i1++)
            {
                for (int i2 = 1; i2 <= pokemons2; i2++)
                {
                    counter++;

                    if (maxBattles < counter)
                    {
                        return;
                    }

                    Console.Write($"({i1} <-> {i2}) ");
                }
            }
        }
    }
}
