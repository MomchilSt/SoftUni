using System;
using System.Collections.Generic;
using System.Linq;

class BasicStackOperations
{
    static void Main()
    {
        int[] numsToWorkWith = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int pushNums = numsToWorkWith[0];
        int popNums = numsToWorkWith[1];
        int checkNum = numsToWorkWith[2];

        int[] expression = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var stack = new Stack<int>();

        for (int i = 0; i < pushNums && i < expression.Length; i++)
        {
            stack.Push(expression[i]);
        }

        for (int i = 0; i < popNums && i < expression.Length; i++)
        {
            stack.Pop();
        }

        if (stack.Count == 0)
        {
            Console.WriteLine("0");
        }
        else if (stack.Contains(checkNum))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(stack.Min());
        }
    }
}
