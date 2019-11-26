using System;
using System.Text.RegularExpressions;

class Regexmon
{
    static void Main()
    {
        string text = Console.ReadLine();

        Regex bojoRegex = new Regex(@"[A-Za-z]+\-[A-Za-z]+");
        Regex didiRegex = new Regex(@"[^A-Za-z\-]+");

        int lastIndex = 0;
        while (true)
        {
            Match didiMatch = didiRegex.Match(text);
            if (!didiMatch.Success) { return; }
            lastIndex = text.IndexOf(didiMatch.Value) + didiMatch.Length;
            text = text.Substring(lastIndex);
            Console.WriteLine(didiMatch);

            Match bojoMatch = bojoRegex.Match(text);
            if (!bojoMatch.Success) { return; }
            lastIndex = text.IndexOf(bojoMatch.Value) + bojoMatch.Length;
            text = text.Substring(lastIndex);
            Console.WriteLine(bojoMatch);
        }
    }
}
