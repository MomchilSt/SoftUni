using System;

namespace _1.Distance
{
    class Program
    {
        static void Main()
        {
            int speed0 = int.Parse(Console.ReadLine());
            int time1 = int.Parse(Console.ReadLine());
            int time2 = int.Parse(Console.ReadLine());
            int time3 = int.Parse(Console.ReadLine());

            double speed1 = speed0 * time1 / 60.0;
            double speed2 = speed0 * 1.1 * time2 / 60.0;
            double speed3 = speed0 * 1.1 * 0.95 * time3 / 60.0;

            Console.WriteLine("{0:f2}", speed1 + speed2 + speed3);
        }
    }
}
