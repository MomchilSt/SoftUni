using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        /*
         var messageCode = Console.ReadLine()
                .Split(' ')
                .Where(x => x.Length == 2)
                .Select(x => new string(x.Reverse().ToArray()))
                .Select(x => Convert.ToChar(Convert.ToInt32(x, 16)))
                .Reverse()
                .ToList();
         Console.WriteLine(string.Join(null ,messageCode));

        */
        List<string> input = Console.ReadLine()
            .Split()
            .Where(x => x.Length == 2)
            .ToList();

        for (int i = 0; i < input.Count; i++)
        {
            string temp = string.Empty;
            char[] value = input[i].ToCharArray();
            temp += value[1];
            temp += value[0];
            input[i] = temp;
        }

        input.Reverse();

        for (int i = 0; i < input.Count; i++)
        {
           char temp = Convert.ToChar(Convert.ToInt32(input[i], 16));
            input[i] = temp.ToString();
        }
        

        Console.WriteLine(string.Join("", input));
    }
}