using System;

namespace _03.HotelRoom
{
    class Program
    {
        static void Main()
        {
            string month = Console.ReadLine().ToLower();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;

            if (month == "may" || month == "october")
            {
                studioPrice = 50 * nights;
                apartmentPrice = 65 * nights;
                if (nights > 14)
                {
                    studioPrice *= .7;
                }
                else if (nights > 7)
                {
                    studioPrice *= .95;
                }
            }
            else if (month == "june" || month == "september")
            {
                studioPrice = 75.20 * nights;
                apartmentPrice = 68.70 * nights;
                if (nights > 14)
                {
                    studioPrice *= .8;
                }
            }
            else if (month == "july" || month == "august")
            {
                studioPrice = 76 * nights;
                apartmentPrice = 77 * nights;
            }

            if (nights > 14)
            {
                apartmentPrice *= .9;
            }

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
