using System;
using System.Linq;

namespace _5.ChristmasHat
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string topDots = new string('.', n * 2 - 1);
            string onlyStars = new string('*', n * 4 + 1);
            string PreLastRow = string.Join("", Enumerable.Repeat("*.", n * 2));

            // Print first top row
            Console.WriteLine(@"{0}/|\{0}", topDots);

            // Print second top row
            Console.WriteLine(@"{0}\|/{0}", topDots);

            // Print middles rows
            for (int i = 0; i < n * 2; i++)
            {
                string middleDots = new string('.', n * 2 - 1 - i);
                string dashes = new string('-', i);

                Console.WriteLine(@"{0}*{1}*{1}*{0}", middleDots, dashes);
            }

            // Print low star row
            Console.WriteLine(onlyStars);

            // Print pre-last row
            Console.WriteLine($"{PreLastRow}*");

            // Print low star row
            Console.WriteLine(onlyStars);
        }
    }
}
