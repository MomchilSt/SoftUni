using System;
using System.Collections.Generic;
using System.Linq;

class ReverseNumbers
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var nums = new Stack<int>(input);

        Console.WriteLine(string.Join(" ", nums));
    }
}