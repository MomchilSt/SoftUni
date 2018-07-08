using System;

class EqualPairs
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int previousSum = 0;
        int currentSum = 0;
        int diff = 0;
        int maxDiff = 0;

        for (int i = 0; i < n; i++)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            if (i == 0)
            {
                previousSum = num1 + num2;
            }
            else
            {
                currentSum = num1 + num2;
                diff = Math.Abs(previousSum - currentSum);
                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }
                previousSum = currentSum;
            }
        }
        if (maxDiff == 0)
        {
            Console.WriteLine("Yes, value = {0}", previousSum);
        }
        else
        {
            Console.WriteLine("No, maxdiff = {0}", maxDiff);
        }
    }
}
