using System;
using System.Linq;

class CryptoMaster
{
    static void Main()
    {
        int[] array = Console.ReadLine()
            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int longestRun = 1;

        for (int i = 0; i < array.Length; i++)
        {
            for (int step = 1; step < array.Length; step++)
            {
                int currentIndex = i;

                int nextIndex = (currentIndex + step) % array.Length;
                int currentRun = 1;

                while (array[nextIndex] > array[currentIndex])
                {
                    currentRun++;
                    if (currentRun > longestRun)
                    {
                        longestRun = currentRun;
                    }


                    currentIndex = nextIndex;
                    nextIndex = (currentIndex + step) % array.Length;
                }
            }
        }

        Console.WriteLine(longestRun);
    }
}