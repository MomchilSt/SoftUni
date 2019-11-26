using System;

class Program
{
    static void Main()
    {
        double n = double.Parse(Console.ReadLine());

        Console.WriteLine($"{(n * 1.60934):F2}");
    }
}
