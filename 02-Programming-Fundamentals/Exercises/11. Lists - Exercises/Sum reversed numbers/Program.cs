using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> numbers = Console.ReadLine()
            .Split()
            .ToList();
        List<int> reversedNums = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            string eachNum = numbers[i];
            char[] element = eachNum.ToCharArray();
            char[] reversed = element.Reverse().ToArray();
            reversedNums.Add(int.Parse(string.Join("", reversed)));
        }
        Console.WriteLine(reversedNums.Sum());
    }
}
