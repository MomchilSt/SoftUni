using System;

namespace USDtoBGN
{
    class Program
    {
        static void Main()
        {
            var USD = double.Parse(Console.ReadLine());
            var BGN = USD * 1.79549;
            Console.WriteLine(Math.Round(BGN, 2) + " BGN");
            // 1 USD = 1.79549 BGN.
        }
    }
}
