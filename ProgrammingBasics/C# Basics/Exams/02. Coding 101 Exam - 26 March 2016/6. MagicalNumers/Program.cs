using System;

namespace _6.MagicalNumers
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i1 = 1; i1 <= 9; i1++)
            {
                for (int i2 = 1; i2 <= 9; i2++)
                {
                    for (int i3 = 1; i3 <= 9; i3++)
                    {
                        for (int i4 = 1; i4 <= 9; i4++)
                        {
                            for (int i5 = 1; i5 <= 9; i5++)
                            {
                                for (int i6 = 1; i6 <= 9; i6++)
                                {
                                    if (n == i1 * i2 * i3 * i4 * i5 * i6)
                                    {
                                        Console.Write($"{i1}{i2}{i3}{i4}{i5}{i6} ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
