using System;

namespace Control_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int controlNum = int.Parse(Console.ReadLine());
            int sum = 0;
            int moves = 0;

            for (int i = 1; i <= n; i++)
            {
                int a = i * 2;
                for (int j = m; j >= 1; j--)
                {
                    int b = j * 3;
                    sum = a + b + sum;
                    moves++;
                    if (sum >= controlNum) break;
                }
                if (sum >= controlNum) break;
            }
            if (sum >= controlNum)
            {
                Console.WriteLine(moves + " moves");
                Console.WriteLine($"Score: {sum} >= {controlNum}");
            }
            else if (sum < controlNum)
            {
                Console.WriteLine(moves + " moves");
            }
        }
    }
}