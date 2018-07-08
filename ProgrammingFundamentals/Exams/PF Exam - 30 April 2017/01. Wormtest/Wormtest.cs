using System;

class Wormtest
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine()) * 100;
        double width = double.Parse(Console.ReadLine());

        if (width == 0)
        {
            Console.WriteLine($"{length * width:F2}");
        }
        else if (length % width == 0)
        {
            Console.WriteLine($"{length * width:F2}");
        }
        else
        {
            Console.WriteLine($"{length / width * 100:F2}%");
        }
    }
}
