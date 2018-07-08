using System;

class P2SignOfIntegerNumber
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        PrintSign(num);
    }

    static void PrintSign(int num)
    {
        if (num > 0)
        {
            Console.WriteLine($"The number {num} is positive.");
        }
        else if (num < 0)
        {
            Console.WriteLine($"The number {num} is negative.");
        }
        else
        {
            Console.WriteLine("The number 0 is zero.");
        }
    }
}
