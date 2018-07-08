using System;

namespace _04.Simple_Loops
{
    class Task4
    {
        static void Main()
        {
            double months = double.Parse(Console.ReadLine());

            double razhod = 0;

            double electricity = 0;
            double water = 0;
            double internet = 0;
            double other = 0;

            double average = 0;


            for (int i = 0; i < months; i++)
            {
                double tok = double.Parse(Console.ReadLine());

                electricity += tok;
                water += 20;
                internet += 15;
                other += (tok + 20 + 15) * 1.2;
            }
            razhod = electricity + water + internet + other;
            average = razhod / months;

            Console.WriteLine($"Electricity: {electricity:f2} lv");
            Console.WriteLine($"Water: {water:f2} lv");
            Console.WriteLine($"Internet: {internet:f2} lv");
            Console.WriteLine($"Other: {other:f2} lv");
            Console.WriteLine($"Average: {average:f2} lv");

        }
    }
}
