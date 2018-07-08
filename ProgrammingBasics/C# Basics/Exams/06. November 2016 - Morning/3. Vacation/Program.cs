using System;

namespace _3.Vacation
{
    class Program
    {
        static void Main()
        {
            int adults = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            string transportType = Console.ReadLine().ToLower();

            double transportPrice = 0;
            double nightsPrice = nights * 82.99;

            if (transportType == "train")
            {
                transportPrice = (adults * 24.99 + students * 14.99) * 2;
                if (adults + students >= 50)
                    transportPrice *= .5;
            }
            else if (transportType == "bus")
            {
                transportPrice = (adults * 32.50 + students * 28.50) *2;
            }
            else if (transportType == "boat")
            {
                transportPrice = (adults * 42.99 + students * 39.99) *2;
            }
            else if (transportType == "airplane")
            {
                transportPrice = (adults * 70.00 + students * 50.00) *2;
            }

            double totalPrice = (transportPrice + nightsPrice) * 1.1;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
