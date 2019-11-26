using System;

class P3NameOfLastDigit
{
    static void Main()
    {
        long n = Math.Abs(long.Parse(Console.ReadLine()));
        NameOfLastDigit(n);
    }
    static void NameOfLastDigit(long n)
    {
        long digit = n % 10;

        if (digit == 0)
        {
            Console.WriteLine("zero");
        }
        else if (digit == 1)
        {
            Console.WriteLine("one");
        }
        else if (digit == 2)
        {
            Console.WriteLine("two");
        }
        else if (digit == 3)
        {
            Console.WriteLine("three");
        }
        else if (digit == 4)
        {
            Console.WriteLine("four");
        }
        else if (digit == 5)
        {
            Console.WriteLine("five");
        }
        else if (digit == 6)
        {
            Console.WriteLine("six");
        }
        else if (digit == 7)
        {
            Console.WriteLine("seven");
        }
        else if (digit == 8)
        {
            Console.WriteLine("eight");
        }
        else if (digit == 9)
        {
            Console.WriteLine("nine");
        }
    }
}
