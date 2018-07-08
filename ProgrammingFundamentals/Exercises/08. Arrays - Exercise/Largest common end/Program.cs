using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] firstLine = Console.ReadLine()
            .Split()
            .ToArray();
        string[] secondLine = Console.ReadLine()
            .Split()
            .ToArray();

        int leftCounter = 0;
        int rightCounter = 0;

        for (int i = 0; i < Math.Min(firstLine.Length, secondLine.Length); i++)
        {
            if (firstLine[i] == secondLine[i])
            {
                leftCounter++;
            }
            else if (firstLine[firstLine.Length - i - 1] == secondLine[secondLine.Length - i - 1])
            {
                rightCounter++;
            }
        }

        if (leftCounter >= rightCounter)
        {
            Console.WriteLine(leftCounter);
        }
        else
        {
            Console.WriteLine(rightCounter);
        }
    }
}
