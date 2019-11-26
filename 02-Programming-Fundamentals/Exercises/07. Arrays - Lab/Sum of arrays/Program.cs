using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int max = Math.Max(array1.Length, array2.Length);

        for (int i = 0; i < max; i++)
        {
            long sum = array1[i % array1.Length] + array2[i % array2.Length];
            Console.Write("{0} ", sum);
        }
        Console.WriteLine();
    }
}