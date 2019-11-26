using System;

class Program
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        if (Math.Abs(a - b) < 5)
        {
            Console.WriteLine("No");
        }
        else
        {
            for (int m1 = a; m1 <= b; m1++)
            {
                for (int m2 = a; m2 <= b; m2++)
                {
                    for (int m3 = a; m3 <= b; m3++)
                    {
                        for (int m4 = a; m4 <= b; m4++)
                        {
                            for (int m5 = a; m5 <= b; m5++)
                            {
                                if (m1 < m2 && m2 < m3 && m3 < m4 && m4 < m5)
                                {
                                    Console.WriteLine("{0} {1} {2} {3} {4}", m1, m2, m3, m4, m5);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
