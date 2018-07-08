using System;

class Program
{
    static void Main()
    {
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());

        if (Math.Abs(n1 - n2) < 5)
        {
            Console.WriteLine("No");
        }
        else
        {

            for (int m1 = n1; m1 <= n2; m1++)
            {

                for (int m2 = n1; m2 <= n2; m2++)
                {

                    for (int m3 = n1; m3 <= n2; m3++)
                    {

                        for (int m4 = n1; m4 <= n2; m4++)
                        {

                            for (int m5 = n1; m5 <= n2; m5++)
                            {
                                if (m1 < m2 && m2 < m3 && m3 < m4 && m4 < m5)
                                {
                                    Console.WriteLine($"{m1} {m2} {m3} {m4} {m5}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
