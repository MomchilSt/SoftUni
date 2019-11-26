using System;

class NumberTableV2
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int num = 0;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                num = i + j - 1;

                if (num > n)
                {
                    for (int k = 1; k <= n - j + 1; k++)
                    {
                        Console.Write("{0} ", n - k);
                    }
                    break;
                }

                Console.Write("{0} ", num);
            }
            Console.WriteLine();
        }
    }
}
