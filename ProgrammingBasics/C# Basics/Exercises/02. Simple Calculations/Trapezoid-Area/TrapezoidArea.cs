using System;

namespace Trapezoid_Area
{
    class TrapezoidArea
    {
        static void Main()
        {
            var b1 = double.Parse(Console.ReadLine());
            var b2 = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());
            Console.WriteLine("Trapezoid Area = " + (b1 + b2) * h / 2);
        }
    }
}
