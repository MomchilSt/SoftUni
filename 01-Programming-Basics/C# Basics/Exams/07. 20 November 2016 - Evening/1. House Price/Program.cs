using System;

namespace _1.House_Price
{
    class Program
    {
        static void Main()
        {
            double areaSmallRoom = double.Parse(Console.ReadLine());
            double kitchen = double.Parse(Console.ReadLine());
            double priceM2 = double.Parse(Console.ReadLine());

            double bath = areaSmallRoom / 2;
            double secondRoom = areaSmallRoom * 1.1;
            double thirdRoom = secondRoom * 1.1;

            double allArea = (areaSmallRoom + kitchen + bath + secondRoom + thirdRoom) * 1.05;
            double price = allArea * priceM2;

            Console.WriteLine($"{price:f2}");
        }
    }
}
