using System;

class Program
{
    static void Main()
    {
        double firstBrother = double.Parse(Console.ReadLine());
        double secondBrother = double.Parse(Console.ReadLine());
        double thirdBrother = double.Parse(Console.ReadLine());
        double fishingTime = double.Parse(Console.ReadLine());

        double time = 1 / ((1 / firstBrother) + (1 / secondBrother) + (1 / thirdBrother));
        double totalTime = time * 1.15;

        if (fishingTime >= totalTime)
        {
            Console.WriteLine($"Cleaning time: {totalTime:f2}");
            Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(fishingTime - totalTime)} hours.");
        }
        else
        {
            Console.WriteLine($"Cleaning time: {totalTime:f2}");
            Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(totalTime - fishingTime)} hours.");
        }
    }
}
