using System;

class P4NumInReversedOrder
{
    static void Main()
    {
        string text = Console.ReadLine();
        string result = Reverse(text);
        Console.WriteLine(result);

    }

    static string Reverse(string text)
    {
        char[] cArray = text.ToCharArray();
        string reverse = string.Empty;
        for (int i = cArray.Length - 1; i > -1; i--)
        {
            reverse += cArray[i];
        }
        return reverse;
    }
}
