using System;
using System.Text.RegularExpressions;

class ReplaceATag
{
    static void Main()
    {
        string tags = Console.ReadLine();
        while (tags != "end")
        {
            string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
            string replacement = @"[URL href=$1]$2[/URL]";
            string replaced = Regex.Replace(
                tags, pattern, replacement);
            Console.WriteLine(replaced);

            tags = Console.ReadLine();
        }
    }
}
