using System;
using System.Collections.Generic;
using System.Linq;

class Palindromes
{
    static void Main()
    {
        string[] words = Console.ReadLine()
            .Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        List<string> palindromes = new List<string>();

        foreach (var word in words)
        {
            if (IsPalindrome(word))
            {
                if (!palindromes.Contains(word))
                {
                    palindromes.Add(word);
                }
            }
        }

        palindromes = palindromes.OrderBy(w => w).ToList();

        Console.WriteLine(string.Join(", ", palindromes));
    }

    private static bool IsPalindrome(string word)
    {
        string firstHalf = word.Substring(0, word.Length / 2);
        string secondHalf = word.Substring((int)Math.Ceiling(word.Length / 2.0));
        secondHalf = new string(secondHalf.Reverse().ToArray());

        if (firstHalf == secondHalf)
        {
            return true;
        }

        return false;
    }
}
