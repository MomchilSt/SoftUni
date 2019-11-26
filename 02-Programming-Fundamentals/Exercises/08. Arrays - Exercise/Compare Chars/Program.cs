using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        char[] firstChar = Console.ReadLine().Split().Select(char.Parse).ToArray();
        char[] secondChar = Console.ReadLine().Split().Select(char.Parse).ToArray();

        if (firstChar.Length < secondChar.Length)
        {
            Console.WriteLine(firstChar);
            Console.WriteLine(secondChar);
        }
        else if (secondChar.Length < firstChar.Length)
        {
            Console.WriteLine(secondChar);
            Console.WriteLine(firstChar);
        }

        else if (firstChar.Length == secondChar.Length)
        {
            for (int i = 0; i < firstChar.Length - 1; i++)
            {
                if (firstChar[i] <= secondChar[i])
                {
                    Console.WriteLine(firstChar);
                    Console.WriteLine(secondChar);
                    return;
                }
                else 
                {
                    Console.WriteLine(secondChar);
                    Console.WriteLine(firstChar);
                    return;
                }
            }
        }
    }
}