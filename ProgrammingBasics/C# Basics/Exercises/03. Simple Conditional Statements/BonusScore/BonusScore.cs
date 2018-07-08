using System;

class BonusScore
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        double bonus = 0;

        if (n <= 100) { bonus += 5; }
        else if (n > 100 && n < 1000) { bonus += n * 0.2; }
        else if (n > 1000) { bonus += n * 0.1; }
        if (n % 2 == 0) { bonus++; }
        else if (n % 10 == 5) { bonus += 2; }

        Console.WriteLine(bonus);
        Console.WriteLine(n + bonus);
    }
}
