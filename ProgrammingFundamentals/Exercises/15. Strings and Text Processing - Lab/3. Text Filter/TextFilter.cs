using System;
using System.Linq;

class TextFilter
{
    static void Main()
    {
        string[] bannedWords = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string text = Console.ReadLine();

        foreach (var word in bannedWords)
        {
            if (text.Contains(word))
            {
                text = text.Replace(word,
                    new string('*', word.Length));
            }
        }

        Console.WriteLine(text);
    }
}
