using System;

class Program
{
    static void Main()
    {
        short num1 = short.Parse(Console.ReadLine());
        short num2 = short.Parse(Console.ReadLine());
        short num3 = short.Parse(Console.ReadLine());
        short num4 = short.Parse(Console.ReadLine());

        Console.WriteLine("{0:d4} {1:d4} {2:d4} {3:d4}", num1, num2, num3, num4);
    }
}
