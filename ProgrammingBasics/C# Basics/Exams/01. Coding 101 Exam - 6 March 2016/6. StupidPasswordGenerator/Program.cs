using System;

namespace _6.StupidPasswordGenerator
{
    class Program
    {
        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());
            byte l = byte.Parse(Console.ReadLine());

            for (int i1 = 1; i1 <= n; i1++)
            {
                for (int i2 = 1; i2 <= n; i2++)
                {
                    for (char i3 = 'a'; i3 < 'a' + l; i3++)
                    {
                        for (char i4 = 'a'; i4 < 'a' + l; i4++)
                        {
                            for (int i5 = 1; i5 <= n; i5++)
                            {
                                if (i5 > i1 && i5 > i2)
                                {
                                    Console.Write($"{i1}{i2}{i3}{i4}{i5} ");
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
