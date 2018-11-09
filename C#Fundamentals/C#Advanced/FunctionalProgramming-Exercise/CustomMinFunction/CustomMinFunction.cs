using System;
using System.Linq;

class CustomMinFunction
{
    static void Main()
    {
        Func<int[], int> findMin = x => x.Min();

        int[] array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine(findMin(array));
    }
}