using System;

class Program
{
    static void Main()
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int magicNum = int.Parse(Console.ReadLine());

        int counter = 0;

        for (int i = num1; i <= num2; i++)
        {

            for (int j = num1; j <= num2; j++)
            {
                counter++;
                if (i + j == magicNum)
                {
                    Console.WriteLine($"Number found! {i} + {j} = {magicNum}");
                    return;
                }
            }
        }
        Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
    }
}
