using System;

class Program
{
    static void Main()
    {
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());

        int bigger = Math.Max(n1, n2);
        int lower = Math.Min(n1, n2);

        for (int i = lower; i <= bigger; i++)
        {
            Console.WriteLine(i);
        }
    }
}
