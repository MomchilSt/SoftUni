using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int m1 = 1; m1 <= 9; m1++)
        {

            for (int m2 = 1; m2 <= 9; m2++)
            {

                for (int m3 = 1; m3 <= 9; m3++)
                {

                    for (int m4 = 1; m4 <= 9; m4++)
                    {
                        if (m1 + m2 == m3 + m4 && n % (m1 + m2) == 0)
                        {
                            Console.Write($"{m1}{m2}{m3}{m4} ");
                        }
                    }
                }
            }
        }
    }
}
