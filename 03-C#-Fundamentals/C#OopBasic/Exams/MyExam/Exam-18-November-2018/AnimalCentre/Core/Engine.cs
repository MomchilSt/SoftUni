using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        public void Run()
        {
            var AnimalCentre = new AnimalCentre();

            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split();
                if (inputArgs[0] == "End")
                {
                    break;
                }

                string[] arguments = inputArgs.Skip(1).ToArray();

                try
                {
                    switch (inputArgs[0])
                    {
                        case "RegisterAnimal":
                            Console.WriteLine(AnimalCentre.RegisterAnimal(arguments[0], arguments[1], int.Parse(arguments[2]), int.Parse(arguments[3]), int.Parse(arguments[4])));
                            break;
                        case "Chip":
                            Console.WriteLine(AnimalCentre.Chip(arguments[0], int.Parse(arguments[1])));
                            break;
                        case "Vaccinate":
                            Console.WriteLine(AnimalCentre.Vaccinate(arguments[0], int.Parse(arguments[1])));
                            break;
                        case "Fitness":
                            Console.WriteLine(AnimalCentre.Fitness(arguments[0], int.Parse(arguments[1])));
                            break;
                        case "Play":
                            Console.WriteLine(AnimalCentre.Play(arguments[0], int.Parse(arguments[1])));
                            break;
                        case "DentalCare":
                            Console.WriteLine(AnimalCentre.DentalCare(arguments[0], int.Parse(arguments[1])));
                            break;
                        case "NailTrim":
                            Console.WriteLine(AnimalCentre.NailTrim(arguments[0], int.Parse(arguments[1])));
                            break;
                        case "Adopt":
                            Console.WriteLine(AnimalCentre.Adopt(arguments[0], arguments[1]));
                            break;
                        case "History":
                            Console.WriteLine(AnimalCentre.History(arguments[0]));
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("InvalidOperationException: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ArgumentException: " + ex.Message);
                }
            }

            var sortedAopted = AnimalCentre.adopted.OrderBy(x => x.Key);

            foreach (var name in sortedAopted)
            {
                Console.WriteLine($"--Owner: {name.Key}");
                Console.Write("    - Adopted animals: ");
                foreach (var animal in name.Value)
                {
                    Console.Write(animal.Name + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
