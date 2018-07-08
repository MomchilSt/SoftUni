using System;

class Fibonacci
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int f0 = 1;
        int f1 = 1;
        int result = 0;

        if (n < 2)
        {
            Console.WriteLine(1);
            return;
        }

        for (int i = 1; i < n; i++)
        {
            result = f0 + f1;
            f0 = f1;
            f1 = result;
        }
        Console.WriteLine(result);
    }
}
