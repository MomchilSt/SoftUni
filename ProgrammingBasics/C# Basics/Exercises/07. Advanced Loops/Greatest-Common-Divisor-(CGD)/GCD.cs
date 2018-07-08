using System;

class GCD
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        while (b != 0)
        {
            int previousB = b;
            b = a % b;
            a = previousB;
        }

        Console.WriteLine(a);
    }
}
