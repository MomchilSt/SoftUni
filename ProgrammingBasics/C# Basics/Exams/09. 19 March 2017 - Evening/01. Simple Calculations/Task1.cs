using System;

namespace _01.Simple_Calculations
{
    class Task1
    {
        static void Main()
        {
            double areaGrape = double.Parse(Console.ReadLine());
            double kgPerMeter = double.Parse(Console.ReadLine());
            double brak = double.Parse(Console.ReadLine());

            double kgGrapes = areaGrape * kgPerMeter - brak;

            double rakia = kgGrapes * 0.45;
            double rakiaL = rakia / 7.5;
            double prihod = rakiaL * 9.8;

            double grapeforSell = kgGrapes * 0.55;
            double grapePrihod = grapeforSell * 1.5;


            Console.WriteLine($"{prihod:f2}");
            Console.WriteLine($"{grapePrihod:f2}");
        }
    }
}
