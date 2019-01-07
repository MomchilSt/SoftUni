﻿using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split();

                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));

                input = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person person = people[index];

            int equalCounter = 0;
            int nonEqualCounter = 0;

            foreach (var man in people)
            {
                if (man.CompareTo(person) == 0)
                {
                    equalCounter++;
                }
                else
                {
                    nonEqualCounter++;
                }
            }

            if (equalCounter > 1)
            {
                Console.WriteLine($"{equalCounter} {nonEqualCounter} {equalCounter + nonEqualCounter}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
