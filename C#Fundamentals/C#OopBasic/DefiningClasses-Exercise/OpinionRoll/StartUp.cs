using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionRoll
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

                people
                .Where(x => x.Age > 30)
                .OrderBy(s => s.Name)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
        }
    }
}
