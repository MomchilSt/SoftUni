using System;
using System.Collections.Generic;

class MagicExchangeableWords
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        char[] chars1 = input[0].ToCharArray();
        char[] chars2 = input[1].ToCharArray();

        bool areExchangeable = AreExchangeable(chars1, chars2);

        Console.WriteLine(areExchangeable.ToString().ToLower());
    }

    private static bool AreExchangeable(char[] chars1, char[] chars2)
    {
        int minLength = Math.Min(chars1.Length, chars2.Length);
        int maxLength = Math.Max(chars1.Length, chars2.Length);

        Dictionary<char, char> charDict = new Dictionary<char, char>();

        // Test 1
        for (int i = 0; i < minLength; i++)
        {
            char symb1 = chars1[i];
            char symb2 = chars2[i];

            if (!charDict.ContainsKey(symb1))
            {
                if (charDict.ContainsValue(symb2))
                {
                    return false;
                }

                charDict[symb1] = symb2;
            }
            else if (charDict[symb1] != symb2)
            {
                return false;
            }
        }

        // Test 2 (executes if char arrays have different lengths)
        if (chars1.Length == maxLength)
        {
            for (int i = minLength; i < chars1.Length; i++)
            {
                char symb = chars1[i];

                if (!charDict.ContainsKey(symb) && !charDict.ContainsValue(symb))
                {
                    return false;
                }
            }
        }
        else
        {
            for (int i = minLength; i < chars2.Length; i++)
            {
                char symb = chars2[i];

                if (!charDict.ContainsKey(symb) && !charDict.ContainsValue(symb))
                {
                    return false;
                }
            }
        }

        // If "Test 1" and "Test 2" are passed, the arrays are exchangeable
        return true;
    }
}
