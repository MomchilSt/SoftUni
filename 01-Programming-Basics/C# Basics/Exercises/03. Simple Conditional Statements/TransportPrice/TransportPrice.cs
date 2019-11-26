using System;

class TransportPrice
{
    static void Main()
    {
        ushort n = ushort.Parse(Console.ReadLine());
        string time = Console.ReadLine();

        var taksiDay = 0.70 + n * 0.79;
        var taksiNight = 0.70 + n * 0.90;
        var bus = n * 0.09;
        var train = n * 0.06;

        var minimum = 0.0;

        if (n < 20 && time == "day")
        {
            minimum = taksiDay;
        }
        if (n < 20 && time == "night")
        {
            minimum = taksiNight;
        }
        if (n >= 20 && n < 100)
        {
            minimum = bus;
        }
        if (n >= 100)
        {
            minimum = train;
        }

        Console.WriteLine("{0}", minimum);
    }
}
