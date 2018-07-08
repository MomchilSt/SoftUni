using System;

class Program
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        int magicNum = int.Parse(Console.ReadLine());

        int counter = 0;
        int counter0 = 0;

        for (int i = start; i <= end; i++)
        {

            for (int j= start; j <= end; j++)
            {
                counter++;
                if (i + j == magicNum)
                {
                    Console.Write($"Combination N:{counter} ");
                    Console.WriteLine($"({i} + {j} = {magicNum})");
                    return;
                }
                else
                {
                    counter0++;
                }
            }
        }
        if (counter0 > 0)
        {
            Console.WriteLine($"{counter0} combinations - neither equals {magicNum}");
        }
    }
}
