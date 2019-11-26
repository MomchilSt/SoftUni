using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] firstString = Console.ReadLine().Split(' ').ToArray();
        string[] secondString = Console.ReadLine().Split(' ').ToArray();

        int left = 0;
        int right = 0;

        for (int i = 0; i < Math.Min(firstString.Length, secondString.Length); i++)
        {
            if (firstString[i] == secondString[i])
            {
                left++;
            }
            else if (firstString[firstString.Length - 1 - i] == secondString[secondString.Length - 1 - i])
            {
                right++;
            }
        }

        if (left >= right)
        {
            Console.WriteLine(left);
        }
        else
        {
            Console.WriteLine(right);
        }
    }
}

