using System;
using System.Linq;

class LettersChangeNumbers
{
    static void Main()
    {
        string[] patterns = Console.ReadLine()
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        decimal sum = 0.0m;
        foreach (string pattern in patterns)
        {
            char leftChar = pattern.ToArray().First();
            char rightChar = pattern.ToArray().Last();
            string middleString = pattern.Substring(1, pattern.Length - 2);

            decimal leftLetterPos = char.ToLower(leftChar) - 96m;
            decimal rightLetterPos = char.ToLower(rightChar) - 96m;
            decimal num = decimal.Parse(middleString);

            decimal currPoints = 0.0m;

            if (char.IsUpper(leftChar))
            {
                currPoints = num / leftLetterPos;
            }
            else
            {
                currPoints = num * leftLetterPos;
            }

            if (char.IsUpper(rightChar))
            {
                currPoints -= rightLetterPos;
            }
            else
            {
                currPoints += rightLetterPos;
            }

            sum += currPoints;
        }

        Console.WriteLine($"{sum:F2}");
    }
}
