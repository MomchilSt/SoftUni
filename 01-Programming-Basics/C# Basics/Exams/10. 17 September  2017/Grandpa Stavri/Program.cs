using System;

class Program
{
    static void Main()
    {
        double n = double.Parse(Console.ReadLine());

        double litersSum = 0;
        double degreesPrint = 0;
        double total = 0;

        for (int i = 0; i < n; i++)
        {
            double liters = double.Parse(Console.ReadLine());
            double degrees = double.Parse(Console.ReadLine());
            litersSum += liters;
            total += liters * degrees;
        }

        degreesPrint = total / litersSum;

        if (degreesPrint < 38)
        {
            Console.WriteLine($"Liter: {litersSum:f2}");
            Console.WriteLine($"Degrees: {degreesPrint:f2}");
            Console.WriteLine("Not good, you should baking!");
        }
        else if (degreesPrint >= 38 && degreesPrint <= 42)
        {
            Console.WriteLine($"Liter: {litersSum:f2}");
            Console.WriteLine($"Degrees: {degreesPrint:f2}");
            Console.WriteLine("Super!");
        }
        else if (degreesPrint > 42)
        {
            Console.WriteLine($"Liter: {litersSum:f2}");
            Console.WriteLine($"Degrees: {degreesPrint:f2}");
            Console.WriteLine("Dilution with distilled water!");
        }
    }
}
