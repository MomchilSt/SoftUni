using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //TODO
        //read input
        //split input
        //rearange to country => city => population ???
        // sum population of each country 
        //print
        var totalPopulation = new Dictionary<string, long>();
        var countriesAndCities = new Dictionary<string, Dictionary<string, long>>();

        while (true)
        {

            string input = Console.ReadLine();

            if (input == "report")
            {
                break;
            }

            string[] token = input.Split('|');
            string city = token[0];
            string country = token[1];
            long population = long.Parse(token[2]);

            if (totalPopulation.ContainsKey(country) == false)
            {
                totalPopulation.Add(country, 0);
                countriesAndCities.Add(country, new Dictionary<string, long>());
            }

            totalPopulation[country] += population;

            countriesAndCities[country].Add(city, population);
        }

        foreach (var country in totalPopulation.OrderByDescending(x => x.Value))
        {
            Dictionary<string, long> cities = countriesAndCities[country.Key];

            Console.WriteLine($"{country.Key} (total population: {country.Value})");

            foreach (var city in cities.OrderByDescending(x=> x.Value))
            {
                Console.WriteLine($"=>{city.Key}: {city.Value}");
            }
        }
    }
}
