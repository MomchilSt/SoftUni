using System;

class P2MaxMethod
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int betweenAAndB = GetMax(a, b);

        int biggest = Math.Max(betweenAAndB, c);
        Console.WriteLine(biggest);
    }
    static int GetMax(int a, int b)
    {
        int bigger = Math.Max(a, b);
        return bigger;
    }
}
