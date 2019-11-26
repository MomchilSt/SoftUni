using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            List<IIdentifiable> collection = new List<IIdentifiable>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split();

                if (tokens.Length == 3)
                {
                    collection.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                else if (tokens.Length == 2)
                {
                    collection.Add(new Robot(tokens[0], tokens[1]));
                }
            }

            string searchNums = Console.ReadLine();

            collection.Where(x => x.Id.EndsWith(searchNums))
                .Select(x => x.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
