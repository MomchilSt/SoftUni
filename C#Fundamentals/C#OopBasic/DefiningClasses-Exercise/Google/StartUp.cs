using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split();
                string name = tokens[0];

                if (people.Any(x => x.Name == name) == false)
                {
                    people.Add(new Person(name));
                }

                Person person = people.Where(x => x.Name == name).First();

                if (input.Contains("company"))
                {
                    string currCompany = tokens[2];
                    string position = tokens[3];
                    decimal salary = decimal.Parse(tokens[4]);

                    person.Company = new Company(currCompany, position, salary);
                }
                else if (input.Contains("pokemon"))
                {
                    string pokemon = tokens[2];
                    string pokemonType = tokens[3];

                    person.Pokemons.Add(new Pokemon(pokemon, pokemonType));
                }
                else if (input.Contains("parents"))
                {
                    string parentName = tokens[2];
                    string parentBirthday = tokens[3];

                    person.Parents.Add(new Parents(parentName, parentBirthday));
                }
                else if (input.Contains("children"))
                {
                    string childName = tokens[2];
                    string childBirthday = tokens[3];

                    person.Children.Add(new Children(childName, childBirthday));
                }
                else if (input.Contains("car"))
                {
                    string model = tokens[2];
                    int speed = int.Parse(tokens[3]);

                    person.Car = new Car(model, speed);
                }
            }

            string command = Console.ReadLine();
            var pers = people.Where(x => x.Name == command).First();

            Console.WriteLine(command);
            Console.WriteLine("Company:");
            if (pers.Company != null)
            {
                Console.WriteLine(pers.Company);
            }
            Console.WriteLine("Car:");
            if (pers.Car != null)
            {
                Console.WriteLine(pers.Car);
            }

            Console.WriteLine("Pokemon:");
            pers.Pokemons.ForEach(p => Console.WriteLine(p));

            Console.WriteLine("Parents:");
            pers.Parents.ForEach(p => Console.WriteLine(p));
            Console.WriteLine("Children:");

            pers.Children.ForEach(c => Console.WriteLine(c));
        }
    }
}
