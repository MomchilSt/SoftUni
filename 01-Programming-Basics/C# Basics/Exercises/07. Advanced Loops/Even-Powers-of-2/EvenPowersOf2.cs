using System;

class EvenPowersOf2
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int num = 1;

        for (int i = 0; i <= n; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(num);
            }
            num *= 2;
        }
    }
}
