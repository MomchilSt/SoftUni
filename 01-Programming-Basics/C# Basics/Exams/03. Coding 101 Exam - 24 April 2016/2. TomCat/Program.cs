using System;

namespace _2.TomCat
{
    class Program
    {
        static void Main()
        {
            int holidays = int.Parse(Console.ReadLine());

            int playHours = holidays * 127 + (365 - holidays) * 63;
            int diff = Math.Abs(playHours - 30000);
            int minsDiff = diff % 60;
            int hoursDiff = diff / 60;

            if (playHours > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play", hoursDiff, minsDiff);
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play", hoursDiff, minsDiff);
            }
        }
    }
}
