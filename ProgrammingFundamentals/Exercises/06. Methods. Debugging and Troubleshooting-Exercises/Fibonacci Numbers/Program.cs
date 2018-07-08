using System;

class P5FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int result = GetFib(n);
        Console.WriteLine(result);
    }

    static int GetFib(int n)
    {
        int result = 0;
        int first = 0;
        int second = 1;

        for (int i = 0; i < n; i++)
        {
            result = first + second;
            first = second;
            second = result;

        }

        if (n == 0)
        {
            result = 1;
        }

        return result;
    }
}
