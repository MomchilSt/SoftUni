using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> registrated = new Dictionary<string, string>();

        int nCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < nCommands; i++)
        {
            string[] input = Console.ReadLine().Split();
            string command = input[0];
            string name = input[1];

            if (command == "register")
            {
                char[] licenseplate = input[2].ToCharArray();
                string licenseStr = input[2];

                bool isUpper = 
                char.IsUpper(licenseplate[0]) &&
                char.IsUpper(licenseplate[1]) &&
                char.IsUpper(licenseplate[6]) &&
                char.IsUpper(licenseplate[7]);

                bool fourDigits =
                char.IsDigit(licenseplate[2]) &&
                char.IsDigit(licenseplate[3]) &&
                char.IsDigit(licenseplate[4]) &&
                char.IsDigit(licenseplate[5]);

                if (isUpper && fourDigits && licenseplate.Length == 8)
                {

                    if (registrated.ContainsKey(name) == false)
                    {
                        if (registrated.ContainsValue(licenseStr))
                        {
                            Console.WriteLine($"ERROR: license plate {licenseStr} is busy");
                            continue;
                        }

                        registrated.Add(name, licenseStr);
                        Console.WriteLine($"{name} registered {licenseStr} successfully");

                    }
                    else if (registrated.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licenseStr}");
                    }
                    else if (registrated[name].Contains(licenseStr))
                    {
                        Console.WriteLine($"ERROR: license plate {licenseStr}");
                    }
                }
                else
                {
                    Console.WriteLine($"ERROR: invalid license plate {licenseStr}");
                }
            }
            else if (command == "unregister")
            {
                if (registrated.ContainsKey(name))
                {
                    registrated.Remove(name);
                    Console.WriteLine($"user {name} unregistered successfully");
                }
                else
                {
                    Console.WriteLine($"ERROR: user {name} not found");
                }
            }
        }
        
        foreach (var name in registrated)
        {
            Console.WriteLine($"{name.Key} => {name.Value}");
        }
    }
}