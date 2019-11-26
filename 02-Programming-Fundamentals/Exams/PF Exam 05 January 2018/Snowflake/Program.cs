using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string surface = Console.ReadLine();
        string mantle = Console.ReadLine();
        string core = Console.ReadLine();
        string mantle2 = Console.ReadLine();
        string surface2 = Console.ReadLine();

        string surfacePatt = @"^([\D\W]+)$";
        string mantlePatt = @"^([\d_]+)$";
        string corePatt = @"^([\D\W]+)([\d_]+)([A-Za-z]+)([\d_]+)([\D\W]+)$";
        string coreLenght = @"([A-Za-z]+)";

        bool surfaceMatch1 = Regex.IsMatch(surface, surfacePatt);
        bool surfaceMatch2 = Regex.IsMatch(surface2, surfacePatt);
        bool mantleMatch1 = Regex.IsMatch(mantle, mantlePatt);
        bool mantleMatch2 = Regex.IsMatch(mantle2, mantlePatt);

        bool coreMatch = Regex.IsMatch(core, corePatt);

        string matchAsStr = Regex.Match(core, coreLenght).ToString();

        if (surfaceMatch1 &&
            surfaceMatch2 &&
            mantleMatch1 &&
            mantleMatch2 &&
            coreMatch)
        {
            Console.WriteLine("Valid");
            Console.WriteLine(matchAsStr.Length);
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }
}