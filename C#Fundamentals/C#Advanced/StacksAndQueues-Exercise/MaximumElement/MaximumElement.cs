using System;
using System.Collections.Generic;
using System.Linq;

class MaximumElement
{
    static void Main()
    {
        var stack = new Stack<int>();

        int inputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputs; i++)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            string action = input[0];

            switch (action)
            {
                case "1":
                    stack.Push(int.Parse(input[1]));
                    break;

                case "2":
                    stack.Pop();
                    break;

                case "3":
                    Console.WriteLine(stack.Max());
                    break;
            }
        }
    }
}
