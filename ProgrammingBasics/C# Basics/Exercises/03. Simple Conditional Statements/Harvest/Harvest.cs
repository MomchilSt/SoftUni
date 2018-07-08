using System;

class Harvest
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        int z = int.Parse(Console.ReadLine());
        int workers = int.Parse(Console.ReadLine());

        var grapesInTotal = x * y;
        var wine = 0.4 * grapesInTotal / 2.5;

        if (wine >= z)
        {
            var littersLeft = wine - z;
            var perWorker = littersLeft / workers;
            Console.WriteLine("Good harvest this year! Total wine: {0} liters.", Math.Floor(wine));
            Console.WriteLine("{0} liters left -> {1} liters per person.", Math.Ceiling(littersLeft), Math.Ceiling(perWorker));
        }
        else
        {
            var neededWine = z - wine;
            Console.WriteLine("It will be a tough winter! More {0} liters wine needed.", Math.Floor(neededWine));
        }
    }
}
