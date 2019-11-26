using System;
using System.Linq;

class UnicodeCharacters
{
    static void Main()
    {
        char[] text = Console.ReadLine().ToCharArray();

        string finalHex = string.Empty;
        foreach (var symb in text)
        {
            string hex = Convert.ToString(symb, 16);
            string zeros = new string('0', 4 - hex.Length);
            string hexChar = $@"\u{zeros}{hex:D4}";
            finalHex += hexChar;
        }

        Console.WriteLine(finalHex);
    }
}
