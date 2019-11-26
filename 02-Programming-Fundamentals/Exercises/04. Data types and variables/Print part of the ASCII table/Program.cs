using System;

class Program
{
    static void Main()
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        for (Char i = (char)num1; i <= (char)num2; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}
