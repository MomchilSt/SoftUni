using ExplicitInterfaces.Interfaces;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                var tokens = command.Split();

                Citizen citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));

                Console.WriteLine(citizen.GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
