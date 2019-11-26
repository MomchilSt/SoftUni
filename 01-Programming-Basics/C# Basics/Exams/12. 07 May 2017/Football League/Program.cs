using System;

class Program
{
    static void Main()
    {
        double capacity = double.Parse(Console.ReadLine());
        double fansNum = double.Parse(Console.ReadLine());

        double sectorA = 0;
        double sectorB = 0;
        double sectorV = 0;
        double sectorG = 0;

        for (int i = 0; i < fansNum; i++)
        {
            string sector = Console.ReadLine().ToLower();

            if (sector == "a")
            {
                sectorA++;
            }
            else if (sector == "b")
            {
                sectorB++;
            }
            else if (sector == "v")
            {
                sectorV++;
            }
            else if (sector == "g")
            {
                sectorG++;
            }
        }

        Console.WriteLine($"{((sectorA / fansNum)*100):f2}%");
        Console.WriteLine($"{((sectorB / fansNum) * 100):f2}%");
        Console.WriteLine($"{((sectorV / fansNum) * 100):f2}%");
        Console.WriteLine($"{((sectorG / fansNum) * 100):f2}%");
        Console.WriteLine($"{((fansNum / capacity) * 100):f2}%");
    }
}
