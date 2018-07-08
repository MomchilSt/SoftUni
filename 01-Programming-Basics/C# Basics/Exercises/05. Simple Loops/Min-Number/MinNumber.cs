﻿using System;

class MinNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int min = int.MaxValue;

        for (int i = 1; i <= n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (num < min)
            {
                min = num;
            }
        }
        Console.WriteLine(min);
    }
}
