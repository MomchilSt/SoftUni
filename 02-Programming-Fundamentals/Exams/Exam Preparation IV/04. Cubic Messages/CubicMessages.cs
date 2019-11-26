using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class CubicMessages
{
    static void Main()
    {
        while (true)
        {
            string code = Console.ReadLine();
            if (code == "Over!") { break; }
            int m = int.Parse(Console.ReadLine());

            string pattern = @"(?<=^)(?<leftDigits>\d+)(?<message>[A-Za-z]{" + m + @"})(?<rightPart>[^A-Za-z]*)(?>$)";
            if (!Regex.IsMatch(code, pattern)) { continue; }

            Match match = Regex.Match(code, pattern);

            string message = match.Groups["message"].ToString();
            string rightPart = match.Groups["rightPart"].ToString();

            string leftDigits = match.Groups["leftDigits"].ToString();
            string rightDigits = string.Join("", rightPart.ToCharArray().Where(x => x - '0' >= 0 && x - '0' <= 9));
            string digits = leftDigits + rightDigits;

            string verification = string.Empty;

            foreach (char symb in digits)
            {
                int index = symb - '0';

                if (index < message.Length)
                {
                    verification += message[index];
                }
                else
                {
                    verification += ' ';
                }
            }

            Console.WriteLine($"{message} == {verification}");
        }
    }
}
