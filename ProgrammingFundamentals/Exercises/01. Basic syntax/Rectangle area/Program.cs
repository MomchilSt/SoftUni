using System;

class Program
{
    static void Main()
    {
        double n1 = double.Parse(Console.ReadLine());
        double n2 = double.Parse(Console.ReadLine());

        Console.WriteLine($"{(n1*n2):f2}");
    }
}
