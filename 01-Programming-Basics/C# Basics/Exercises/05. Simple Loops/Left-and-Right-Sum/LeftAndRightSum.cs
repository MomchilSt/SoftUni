﻿using System;

class LeftAndRightSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int leftSum = 0;
        int rightSum = 0;

        for (int i = 1; i <= n; i++)
        {
            leftSum = leftSum + int.Parse(Console.ReadLine());
        }
        for (int i = 1; i <= n; i++)
        {
            rightSum = rightSum + int.Parse(Console.ReadLine());
        }

        if (leftSum == rightSum)
        {
            Console.WriteLine("Yes, sum = {0}", leftSum);
        }
        else
        {
            Console.WriteLine("No, diff = {0}", Math.Abs(leftSum - rightSum));
        }
    }
}
