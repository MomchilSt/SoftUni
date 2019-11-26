using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] textInput = Console.ReadLine()
            .Split(new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        List<string> lowerCase = new List<string>();
        List<string> uppperCase = new List<string>();
        List<string> mixed = new List<string>();

        foreach (var text in textInput)
        {
            if (IsUpperWord(text))
            {
                uppperCase.Add(text);
            }
            else if (IsLowerWord(text))
            {
                lowerCase.Add(text);
            }
            else
            {
                mixed.Add(text);
            }
        }
        Console.WriteLine("Lower-case: " + string.Join(", ", lowerCase));
        Console.WriteLine("Mixed-case: " + string.Join(", ", mixed));
        Console.WriteLine("Upper-case: " + string.Join(", ", uppperCase));


    }

    static bool IsUpperWord(string textInput)
    {
        foreach (char symbol in textInput)
        {
            if (symbol < 'A' || symbol > 'Z')
            {
                return false;
            }
        }
        return true;
    }

    static bool IsLowerWord(string textInput)
    {
        foreach (char symbol in textInput)
        {
            if (symbol < 'a' || symbol > 'z')
            {
                return false;
            }
        }
        return true;
    }
}

