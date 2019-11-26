using System;

class CharityMarathon
{
    static void Main()
    {
        long maratonDays = long.Parse(Console.ReadLine());
        long runnersCount = long.Parse(Console.ReadLine());
        long averageLapsPerRunner = long.Parse(Console.ReadLine());
        long trackLength = long.Parse(Console.ReadLine());
        long trackCapacity = long.Parse(Console.ReadLine());
        decimal moneyPerKm = decimal.Parse(Console.ReadLine());

        long totalCapacity = trackCapacity * maratonDays;

        if (runnersCount > totalCapacity)
        {
            runnersCount = totalCapacity;
        }

        long totalMeters = runnersCount * averageLapsPerRunner * trackLength;
        decimal totalKms = totalMeters / 1000.0m;
        decimal totalMoney = totalKms * moneyPerKm;

        Console.WriteLine($"Money raised: {totalMoney:F2}");
    }
}
