using System;

class Program
{
    static void Main()
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int specialNum = int.Parse(Console.ReadLine());

        int sum = 0;
        int counter = 0;
        int result = 0;

        for (int i = num1; i >= 1; i--)
        {
            for (int j = 1; j <= num2; j++)
            {
                counter++;
                result = i * j;
                result *= 3;
                sum += result;
                result -= result;

                if (sum >= specialNum)
                {
                    Console.WriteLine($"{counter} combinations");
                    Console.WriteLine($"Sum: {sum} >= {specialNum}");
                    return;
                }
            }
        }
        Console.WriteLine($"{counter} combinations");
        Console.WriteLine($"Sum: {sum}");
    }
}
