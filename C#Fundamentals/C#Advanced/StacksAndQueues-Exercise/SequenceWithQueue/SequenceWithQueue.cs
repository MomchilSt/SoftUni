using System;
using System.Collections.Generic;
using System.Linq;

class SequenceWithQueue
{
    static void Main()
    {
        long num = long.Parse(Console.ReadLine());

        List<long> result = new List<long>();
        var queue = new Queue<long>();

        queue.Enqueue(num);
        result.Add(num);

        for (int i = 0; i < 50; i++)
        {
            long current = queue.Dequeue();

            long a = current + 1;
            long b = current * 2 + 1;
            long c = current + 2;

            queue.Enqueue(a);
            queue.Enqueue(b);
            queue.Enqueue(c);

            result.Add(a);
            result.Add(b);
            result.Add(c);
        }

        Console.WriteLine(string.Join(" ", result.Take(50)));
    }
}
