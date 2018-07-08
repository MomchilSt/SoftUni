using System;

class Program
{
    static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int controlNum = int.Parse(Console.ReadLine());

        int sum = 0;
        int counter = 0;

        for (int m1 = 1; m1 <= firstNum; m1++)
        {
            int a = m1 * 2;
            for (int m2 = secondNum; m2 >= 1; m2--)
            {
                int b = m2 * 3;
                sum = a + b + sum;
                counter++;
                

                if (sum >= controlNum)
                {
                    break;
                }
            }

            if (sum >= controlNum)
            {
                break;
            }
        }

        if (sum >= controlNum)
        {
            Console.WriteLine(counter + " moves");
            Console.WriteLine($"Score: {sum} >= {controlNum}");
        }
        else if (sum < controlNum)
        {
            Console.WriteLine(counter + " moves");
        }
    }
}
