using System;
using System.Collections.Generic;
using System.Linq;

class Evolution
{
    public string Type { get; set; }
    public int Index { get; set; }
}

class Program
{
    static void Main()
    {
        Dictionary<string, List<Evolution>> pokemons = new Dictionary<string, List<Evolution>>();
        
        while (true)
        {
            string[] input = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "wubbalubbadubdub") { break; }
            string pokemonName = input[0];

            if (input.Length == 1)
            {
                if (pokemons.ContainsKey(pokemonName))
                {
                    PrintEvolution(pokemons, pokemonName);
                }

                continue;
            }

            string evolutionType = input[1];
            int evolutionIndex = int.Parse(input[2]);

            Evolution evolution = new Evolution()
            {
                Type = evolutionType,
                Index = evolutionIndex
            };

            if (!pokemons.ContainsKey(pokemonName))
            {
                pokemons[pokemonName] = new List<Evolution>();
            }

            pokemons[pokemonName].Add(evolution);
        }

        for (int i = 0; i < pokemons.Count; i++)
        {
            var item = pokemons.ElementAt(i);
            var name = item.Key;
            var evol = item.Value;

            pokemons[name] = evol.OrderByDescending(x => x.Index).ToList();
        }

        PrintPokemons(pokemons);
    }

    private static void PrintEvolution(Dictionary<string, List<Evolution>> pokemons, string pokemonName)
    {
        Console.WriteLine($"# {pokemonName}");

        foreach (Evolution evol in pokemons[pokemonName])
        {
            Console.WriteLine($"{evol.Type} <-> {evol.Index}");
        }
    }

    static void PrintPokemons(Dictionary<string, List<Evolution>> pokemons)
    {
        foreach (KeyValuePair<string, List<Evolution>> item in pokemons)
        {
            Console.WriteLine($"# {item.Key}");

            foreach (Evolution evol in item.Value)
            {
                Console.WriteLine($"{evol.Type} <-> {evol.Index}");
            }
        }
    }
}
