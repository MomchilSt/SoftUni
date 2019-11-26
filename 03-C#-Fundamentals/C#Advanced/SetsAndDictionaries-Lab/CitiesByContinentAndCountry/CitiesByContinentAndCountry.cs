using System;
using System.Collections.Generic;

class CitiesByContinentAndCountry
{
    static void Main()
    {
        var dictionary = new Dictionary<string, Dictionary<string, List<string>>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split();

            string continent = input[0];
            string country = input[1];
            string city = input[2];

            if (dictionary.ContainsKey(continent) == false)
            {
                dictionary.Add(continent, new Dictionary<string, List<string>>());
            }
            if (dictionary.ContainsKey(continent) && dictionary[continent].ContainsKey(country) == false)
            {
                dictionary[continent].Add(country, new List<string>());
            }

            dictionary[continent][country].Add(city);
        }

        foreach (var continent in dictionary)
        {
            Console.WriteLine(continent.Key + ":");

            foreach (var country in continent.Value)
            {
                Console.Write(country.Key + " -> ");

                for (int i = 0; i < country.Value.Count; i++)
                {
                    if (i == country.Value.Count - 1)
                    {
                        Console.Write(country.Value[i]);
                    }
                    else
                    {
                        Console.Write(country.Value[i] + ", ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}