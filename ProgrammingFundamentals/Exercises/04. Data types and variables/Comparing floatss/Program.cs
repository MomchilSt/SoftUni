using System;

class Program
{
    static void Main()
    {
        decimal num1 = decimal.Parse(Console.ReadLine());
        decimal num2 = decimal.Parse(Console.ReadLine());

        decimal diff = Math.Max(num1, num2) - Math.Min(num1, num2);

        if (diff < 0.000001m)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}
