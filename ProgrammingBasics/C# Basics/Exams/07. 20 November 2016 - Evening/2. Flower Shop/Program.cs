using System;

namespace _2.Flower_Shop
{
    class Program
    {
        static void Main()
        {
            double magnolii = double.Parse(Console.ReadLine()) * 3.25;
            double zioumbiuli = double.Parse(Console.ReadLine()) * 4;
            double roses = double.Parse(Console.ReadLine()) * 3.5;
            double cactuses = double.Parse(Console.ReadLine()) * 8;
            double price = double.Parse(Console.ReadLine());

            double sum = (magnolii + zioumbiuli + roses + cactuses) * 0.95;
            double diff = Math.Abs(sum - price);

            if (sum >= price)
                Console.WriteLine($"She is left with {Math.Floor(diff)} leva.");
            else
                Console.WriteLine($"She will have to borrow {Math.Ceiling(diff)} leva.");
                 
        }
    }
}
