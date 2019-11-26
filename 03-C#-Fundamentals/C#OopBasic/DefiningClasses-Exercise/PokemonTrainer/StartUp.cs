using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }

                string[] tokens = input.Split();
                string trainerName = tokens[0];
                string currPokemon = tokens[1];
                string element = tokens[2];
                int health = int.Parse(tokens[3]);

                if (trainers.Any(t => t.Name == trainerName) == false)
                {
                    trainers.Add(new Trainer(trainerName));
                }

                var trainer = trainers.First(t => t.Name == trainerName);
                trainer.Pokemons.Add(new Pokemon(currPokemon, element, health));
            }

            while (true)
            {
                string element = Console.ReadLine();
                if (element == "End")
                {
                    break;
                }

                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                    }
                }
            }

            foreach (Trainer trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count()}");
            }
        }
    }
}
