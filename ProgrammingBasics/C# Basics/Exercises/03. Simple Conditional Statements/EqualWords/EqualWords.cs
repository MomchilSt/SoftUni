using System;

class EqualWords
{
    static void Main()
    {
        string word1 = Console.ReadLine();
        string word2 = Console.ReadLine();

        string word1ToLower = word1.ToLower();
        string word2ToLower = word1.ToLower();

        if (word1ToLower == word2ToLower)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}
