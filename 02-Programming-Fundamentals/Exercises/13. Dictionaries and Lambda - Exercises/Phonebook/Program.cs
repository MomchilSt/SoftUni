using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var dict = new Dictionary<string, string>();

        while (true)
        {
           string [] input = Console.ReadLine().Split();
            if (input[0] == "END")
            {
                break;
            }
            else if (input[0] == "A")
            {
                if (dict.ContainsKey(input[1]) == false)
                {
                    dict.Add(input[1], input[2]);
                }
                else
                {
                    dict[input[1]] = input[2];
                }
            }
            if (input[0] == "S")
            {
                if (dict.ContainsKey(input[1]) == false)
                {
                    Console.WriteLine($"Contact {input[1]} does not exist.");
                }
                else
                {
                    //string value = string.Empty;
                    //var founded = dict.TryGetValue(input[1], out value);
                    string value = dict[input[1]];
                    Console.WriteLine($"{input[1]} -> {value}");
                }
            }
        }
    }
}
