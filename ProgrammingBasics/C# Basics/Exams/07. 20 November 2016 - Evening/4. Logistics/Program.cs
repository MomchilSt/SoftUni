using System;

namespace _4.Logistics
{
    class Program
    {
        static void Main()
        {
            double n = double.Parse(Console.ReadLine());

            double price = 0;
            double tons = 0;

            double tons1 = 0;
            double tons2 = 0;
            double tons3 = 0;

            for (int i = 0; i < n; i++)
            {
                double weight = double.Parse(Console.ReadLine());

                tons += weight;

                if (weight <= 3)
                {
                    price += 200 * weight;
                    tons1 += weight;
                }
                else if (weight >= 4 && weight <= 11)
                {
                    price += 175 * weight;
                    tons2 += weight;
                }
                else
                {
                    price += 120 * weight;
                    tons3 += weight;
                }
            }

            double average = price / tons;

            double n1 = tons1 / tons * 100;
            double n2 = tons2 / tons * 100;
            double n3 = tons3 / tons * 100;

            Console.WriteLine($"{average:f2}");
            Console.WriteLine($"{n1:f2}%");
            Console.WriteLine($"{n2:f2}%");
            Console.WriteLine($"{n3:f2}%");
        }
    }
}
