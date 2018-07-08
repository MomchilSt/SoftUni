using System;

namespace _1.TailsRepair
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double l = double.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int o = int.Parse(Console.ReadLine());

            double tale = w * l;
            double seat = m * o;
            double totalArea = n * n - seat;
            double tilesCount = totalArea / tale;
            double time = tilesCount * 0.2;

            Console.WriteLine(tilesCount);
            Console.WriteLine(time);
        }
    }
}
