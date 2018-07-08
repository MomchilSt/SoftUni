using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var dict = new Dictionary<string, string>();

        while (true)
        {
            string names = Console.ReadLine();

            if (names == "stop")
            {
                break;
            }

            string emails = Console.ReadLine();

            if (!emails.Contains(".us"))
            {
                dict.Add(names, emails);
            }
        }

        foreach (var kvp in dict)
        {
            Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
        }
    }
}
