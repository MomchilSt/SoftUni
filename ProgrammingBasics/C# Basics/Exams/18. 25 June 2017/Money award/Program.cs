using System;

class Program
{
    static void Main()
    {
        int partsOfTheProject = int.Parse(Console.ReadLine());
        double prizePerPoint = double.Parse(Console.ReadLine());

        double sum = 0;

        for (int i = 1; i <= partsOfTheProject; i++)
        {
            double prize = double.Parse(Console.ReadLine());

            if (i % 2 == 0)
            {
                sum += prize * 2;
            }
            else
            {
                sum += prize;
            }
        }
        Console.WriteLine($"The project prize was {(prizePerPoint * sum):f2} lv.");
    }
}
