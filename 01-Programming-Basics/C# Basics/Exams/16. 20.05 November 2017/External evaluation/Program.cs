using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double poor = 0;
        double satisfactory = 0;
        double good = 0;
        double veryGood = 0;
        double excellent = 0;

        for (int i = 0; i < n; i++)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade <= 22.5)
            {
                poor++;
            }
            else if (grade > 22.5 && grade <= 40.5)
            {
                satisfactory++;
            }
            else if (grade > 40.5 && grade <= 58.5)
            {
                good++;
            }
            else if (grade > 58.5 && grade <= 76.5)
            {
                veryGood++;
            }
            else if (grade > 76.5 && grade <= 100)
            {
                excellent++;
            }
        }

        Console.WriteLine($"{((poor/n)*100):f2}% poor marks");
        Console.WriteLine($"{((satisfactory / n) * 100):f2}% satisfactory marks");
        Console.WriteLine($"{((good / n) * 100):f2}% good marks");
        Console.WriteLine($"{((veryGood / n) * 100):f2}% very good marks");
        Console.WriteLine($"{((excellent / n) * 100):f2}% excellent marks");
    }
}
