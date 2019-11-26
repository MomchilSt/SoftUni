using System;

class Program
{
    static void Main()
    {
        int end = int.Parse(Console.ReadLine());
        int start = int.Parse(Console.ReadLine());
        int magicNum = int.Parse(Console.ReadLine());

        int counter = 0;

        for (int i = end; i >= start; i--)
        {

            for (int j = end; j >= start; j--)
            {
                counter++;
                if (i + j == magicNum)
                {
                    Console.Write($"Combination N:{counter} ");
                    Console.WriteLine($"({i} + {j} = {magicNum})");
                    return;
                }
            }
        }
        Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
    }
}
