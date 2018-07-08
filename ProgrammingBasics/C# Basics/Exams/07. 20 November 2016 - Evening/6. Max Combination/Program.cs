using System;

namespace _6.Max_Combination
{
    class Program
    {
        static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i1 = start; i1 <= finish; i1++)
            {
                for (int i2 = start; i2 <= finish; i2++)
                {
                    count++;

                    if (count <= max)
                    {
                        Console.Write($"<{i1}-{i2}>");
                    }
                }
            }
        }
    }
}
