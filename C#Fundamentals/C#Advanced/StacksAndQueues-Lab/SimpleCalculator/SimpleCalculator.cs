using System;
using System.Collections.Generic;

class SimpleCalculator
{
    static void Main()
    {
        string[] expression = Console.ReadLine()
            .Split();

        Stack<int> nums = new Stack<int>();

        bool isPositive = true;

        foreach (var number in expression)
        {
            switch (number)
            {
                case "-":
                    isPositive = false;
                    break;

                case "+":
                    isPositive = true;
                    break;

                default:
                    int currentNumber = int.Parse(number);

                    if (!isPositive)
                    {
                        currentNumber *= -1;
                    }

                    nums.Push(currentNumber);
                    break;
            }
        }

        int result = 0;

        foreach (var num in nums)
        {
            result += num;
        }

        Console.WriteLine(result);
    }
}