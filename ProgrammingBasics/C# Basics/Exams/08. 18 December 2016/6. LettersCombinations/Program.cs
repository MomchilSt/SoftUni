using System;

namespace _6.LettersCombinations
{
    class Program
    {
        static void Main()
        {
            char sim1 = char.Parse(Console.ReadLine());
            char sim2 = char.Parse(Console.ReadLine());
            char sim3 = char.Parse(Console.ReadLine());

            int count = 0;

            for (char i1 = sim1; i1 <= sim2; i1++)
            {
                for (char i2 = sim1; i2 <= sim2; i2++)
                {
                    for (char i3 = sim1; i3 <= sim2; i3++)
                    {
                        if (i1 != sim3 && i2 != sim3 && i3 != sim3)
                        {
                            Console.Write($"{i1}{i2}{i3} ");
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
