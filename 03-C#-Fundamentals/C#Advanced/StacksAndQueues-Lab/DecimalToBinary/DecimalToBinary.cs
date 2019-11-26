using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        if (num == 0)
        {
            Console.WriteLine(0);
            return;
        }

        Stack<int> stack = new Stack<int>();

        while (num > 0)
        {
            int result = num % 2;
            stack.Push(result);
            num /= 2;
        }

        Console.WriteLine(string.Join("", stack));
    }
}