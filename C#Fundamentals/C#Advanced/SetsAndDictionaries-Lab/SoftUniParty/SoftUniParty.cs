using System;
using System.Collections.Generic;

class SoftUniParty
{
    static void Main()
    {
        HashSet<string> guests = new HashSet<string>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "PARTY")
            {
                break;
            }

            guests.Add(input);
        }

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            guests.Remove(input);
        }

        Console.WriteLine(guests.Count);
        Console.WriteLine(string.Join("\n", guests));
    }
}