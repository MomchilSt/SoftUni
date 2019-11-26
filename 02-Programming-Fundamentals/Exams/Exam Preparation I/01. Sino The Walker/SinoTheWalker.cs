using System;
using System.Globalization;

class SinoTheWalker
{
    static void Main()
    {
        DateTime time = DateTime.ParseExact(
            Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
        int steps = int.Parse(Console.ReadLine()) % 86400;
        int secondsPerStep = int.Parse(Console.ReadLine()) % 86400;

        time = time.AddSeconds(steps * secondsPerStep);
        Console.WriteLine($"Time Arrival: {time:HH:mm:ss}");
    }
}
