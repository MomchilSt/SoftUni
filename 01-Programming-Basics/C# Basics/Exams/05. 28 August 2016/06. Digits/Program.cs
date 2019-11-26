using System;

namespace _06.Digits
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int digit1 = n / 100;
            int digit2 = n % 100 / 10;
            int digit3 = n % 10;

            for (int i = 0; i < digit1 + digit2; i++)
            {
                for (int k = 0; k < digit1 + digit3; k++)
                {
                    if (n % 5 == 0 || n % 3 == 0)
                    {
                        if (n % 5 == 0)
                            n -= digit1;
                        else if (n % 3 == 0)
                            n -= digit2;
                    }
                    else
                        n += digit3;

                    Console.Write($"{n} ");
                }
                Console.WriteLine();
            }
        }
    }
}
