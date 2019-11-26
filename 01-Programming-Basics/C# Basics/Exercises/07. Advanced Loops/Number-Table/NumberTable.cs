using System;

class NumberTable
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int num = 0;

        for (int i = 1; i <= n / 2; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                num = i + j - 1;
                if (num > n)
                {
                    num = j - 1;
                }
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
        }

        for (int i = 1; i <= n / 2; i++)
        {
            for (int j = 1; j <= n; j++)
            {

            }
            Console.WriteLine();
        }


        //    n = 4               n = 5
        //
        //   1 2 3 4            1 2 3 4 5
        //   2 3 4 3            2 3 4 5 4
        //   3 4 3 2            3 4 5 4 3
        //   4 3 2 1            4 5 4 3 2
        //                      5 4 3 2 1
    }
}
