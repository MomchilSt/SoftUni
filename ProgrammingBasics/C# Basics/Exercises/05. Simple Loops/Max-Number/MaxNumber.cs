﻿using System;

class MaxNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int max = int.MinValue;

        for (int i = 1; i <= n; i++)
        {
            int num = int.Parse(Console.ReadLine());

            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine(max);
    }
}