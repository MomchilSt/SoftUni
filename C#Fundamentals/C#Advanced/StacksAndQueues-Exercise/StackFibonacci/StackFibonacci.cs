using System;
using System.Collections.Generic;

class StackFibonacci
{
    static void Main()
    {
        var fibonacci = new Stack<long>();

        long n = long.Parse(Console.ReadLine());

        fibonacci.Push(0);
        fibonacci.Push(1);

        for (int i = 0; i < n - 1; i++)
        {
            long firstNum = fibonacci.Pop();
            long secondNum = fibonacci.Peek();

            fibonacci.Push(firstNum);
            fibonacci.Push(firstNum + secondNum);
        }

        Console.WriteLine(fibonacci.Peek());
    }
}