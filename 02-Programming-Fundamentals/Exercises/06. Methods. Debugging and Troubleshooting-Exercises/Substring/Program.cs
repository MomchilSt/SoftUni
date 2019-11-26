using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());

        const char Search = 'p';
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == Search)
            {
                hasMatch = true;

                int lenght = jump + 1;
                string matchedString = string.Empty;

                if (i + lenght <= text.Length)
                {
                    matchedString = text.Substring(i, lenght);
                }
                else
                {
                    matchedString = text.Substring(i);
                }
                
                Console.WriteLine(matchedString);
                i += jump;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
