using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string text = Console.ReadLine();
        string pattern = 
            @"(?<=\s|^)[a-zA-Z0-9]+[\.\-\w]*[a-zA-Z0-9]+@[a-zA-Z0-9]+[\.\-\w]*\.[a-zA-Z0-9]+";

        MatchCollection emails = Regex.Matches(text, pattern);

        foreach (Match email in emails)
        {
            Console.WriteLine(email);
        }
    }
}
