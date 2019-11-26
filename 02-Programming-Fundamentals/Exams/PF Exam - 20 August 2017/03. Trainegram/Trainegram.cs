using System;
using System.Text.RegularExpressions;

class Trainegram
{
    static void Main()
    {
        Regex regex = new Regex(@"^\<\[[^A-Za-z0-9]*\]\.(\.\[[A-Za-z0-9]*\]\.)*$");

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Traincode!") { break; }

            if (regex.IsMatch(input))
            {
                Console.WriteLine(input);
            }
        }
    }
}
