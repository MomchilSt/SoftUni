using System;
using System.Collections.Generic;

class ReverseStrings
{
    static void Main()
    {
        Stack<char> reverse = new Stack<char>();

        string input = Console.ReadLine();

        foreach (var item in input)
        {
            reverse.Push(item);
        }

        while (true)
        {
            if (reverse.Count == 0)
            {
                break;
            }
            else
            {
                Console.Write(reverse.Pop());
            }
        }
        Console.WriteLine();
    }
}
