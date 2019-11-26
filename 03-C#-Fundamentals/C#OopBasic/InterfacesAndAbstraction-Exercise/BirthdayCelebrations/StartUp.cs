using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main()
        {
            List<IBirthdate> collection = new List<IBirthdate>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split();

                switch (tokens[0])
                {
                    case "Citizen":
                        collection.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                            break;

                    case "Pet":
                        collection.Add(new Pet(tokens[1], tokens[2]));
                        break;

                    default:
                        break;
                }
            }
            string year = Console.ReadLine();

            collection.Where(c => c.Birthdate.EndsWith(year))
                        .Select(c => c.Birthdate)
                        .ToList()
                        .ForEach(dt => Console.WriteLine(dt));
        }
    }
}
