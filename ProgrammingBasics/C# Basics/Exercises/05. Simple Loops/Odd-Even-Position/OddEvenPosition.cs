using System;

class OddEvenPosition
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double oddSum = 0;
        double oddMin = double.MaxValue;
        double oddMax = double.MinValue;

        double evenSum = 0;
        double evenMin = double.MaxValue;
        double evenMax = double.MinValue;

        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                double oddNum = double.Parse(Console.ReadLine());

                oddSum += oddNum;
                if (oddNum < oddMin)
                {
                    oddMin = oddNum;
                }
                if (oddNum > oddMax)
                {
                    oddMax = oddNum;
                }
            }
            else
            {
                double evenNum = double.Parse(Console.ReadLine());

                evenSum += evenNum;
                if (evenNum < evenMin)
                {
                    evenMin = evenNum;
                }
                if (evenNum > evenMax)
                {
                    evenMax = evenNum;
                }
            }
        }

        Console.WriteLine("OddSum = {0}", oddSum);
        if (oddMin == double.MaxValue)
        {
            Console.WriteLine("OddMin = No");
        }
        else
        {
            Console.WriteLine("OddMin = {0}", oddMin);
        }
        if (oddMax == double.MinValue)
        {
            Console.WriteLine("OddMax = No");
        }
        else
        {
            Console.WriteLine("OddMax = {0}", oddMax);
        }

        Console.WriteLine("EvenSum = {0}", evenSum);
        if (evenMin == double.MaxValue)
        {
            Console.WriteLine("EvenMin = No");
        }
        else
        {
            Console.WriteLine("EvenMin = {0}", evenMin);
        }
        if (evenMax == double.MinValue)
        {
            Console.WriteLine("EvenMax = No");
        }
        else
        {
            Console.WriteLine("EvenMax = {0}", evenMax);
        }
    }
}
