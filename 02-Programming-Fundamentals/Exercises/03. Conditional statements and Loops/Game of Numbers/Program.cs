using System;

class Program
{
    static void Main()
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int magicNum = int.Parse(Console.ReadLine());

        int counter = 0;

        for (int m1 = num1; m1 <= num2; m1++)
        {

            for (int m2 = num1; m2 <= num2; m2++)
            {
                counter++;

                if (m1 + m2 == magicNum)
                {
                    Console.WriteLine($"Number found! {m2} + {m1} = {magicNum}");
                    return;
                }
            }
        }
        Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
    }
}
