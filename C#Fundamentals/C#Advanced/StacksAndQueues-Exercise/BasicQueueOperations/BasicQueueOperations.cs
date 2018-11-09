using System;
using System.Collections.Generic;
using System.Linq;

class BasicQueueOperations
{
    static void Main()
    {
        var queue = new Queue<int>();

        int[] workNums = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[] expression = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int addNums = workNums[0];
        int removeNums = workNums[1];
        int checkNum = workNums[2];

        for (int i = 0; i < addNums; i++)
        {
            queue.Enqueue(expression[i]);
        }

        for (int i = 0; i < removeNums; i++)
        {
            queue.Dequeue();
        }

        if (queue.Count == 0)
        {
            Console.WriteLine("0");
        }
        else if (queue.Contains(checkNum))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(queue.Min());
        }
    }
}
