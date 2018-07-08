using System;

namespace _06.Advanced_Loops
{
    class Task6
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());

            int sum = 0;
            int count = 0;

            for (int i1 = 1; i1 <= n; i1++)
            {
                for (int i2 = m; i2 >= 1; i2--)
                {
                    if (sum < num)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }

                    sum += i1 * 2 + i2 * 3;
                }
            }

            Console.WriteLine($"{count} moves");
            if (sum >= num)
            {
                Console.WriteLine($"Score: {sum} >= {num}");
            }
        }
    }
}
