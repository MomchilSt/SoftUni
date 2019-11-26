using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        char[] charArr = input.ToCharArray();
        

        for (int i = 0; i < charArr.Length; i++)
        {
            char currentChar = Convert.ToChar(0);
            char asNumber = charArr[i];

            Console.WriteLine($"{charArr[i]} -> {asNumber - 97}");
        }
    }
}
