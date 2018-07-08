using System;

class HalfSumElement
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int max = int.MinValue;
        int sum = 0;

        for (int i = 1; i <= n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            sum += num;
            if (num > max)
            {
                max = num;
            }
        }
        if (max == sum - max)
        {
            Console.WriteLine("Yes{0}Sum = {1}", Environment.NewLine, sum - max);
        }
        else
        {
            Console.WriteLine("No{0}Diff = {1}", Environment.NewLine, Math.Abs((sum - max) - max));
        }
    }
}
