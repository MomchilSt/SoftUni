using System;

namespace _1.Fishland
{
    class Program
    {
        static void Main()
        {
            double mackerelPrice = double.Parse(Console.ReadLine()); //скумрия
            double spratPrice = double.Parse(Console.ReadLine()); // цаца
            double beltedBonitoKg = double.Parse(Console.ReadLine()); // паламуд
            double scadKg = double.Parse(Console.ReadLine()); // сафрид
            double clamsKg = double.Parse(Console.ReadLine()); // миди

            double beltedBonitoPrice = mackerelPrice * 1.6;
            double scadPrice = spratPrice * 1.8;
            double clamsPrice = 7.5;

            double beltedBonito = beltedBonitoPrice * beltedBonitoKg;
            double scad = scadPrice * scadKg;
            double clams = clamsPrice * clamsKg;

            double priceTotal = beltedBonito + scad + clams;

            Console.WriteLine($"{priceTotal:f2}");
        }
    }
}
