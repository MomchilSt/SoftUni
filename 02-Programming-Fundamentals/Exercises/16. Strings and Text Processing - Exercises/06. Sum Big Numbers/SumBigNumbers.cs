using System;
using System.Linq;

class SumBigNumbers
{
    static void Main()
    {
        string num1 = Console.ReadLine().TrimStart('0').Trim();
        string num2 = Console.ReadLine().TrimStart('0').Trim();

        int maxLength = Math.Max(num1.Length, num2.Length);
        int minLength = Math.Min(num1.Length, num2.Length);

        if (num1.Length != num2.Length)
        {
            string zeros = new string('0', maxLength - minLength);

            if (num1.Length < num2.Length)
            {
                num1 = $"{zeros}{num1}";
            }
            else
            {
                num2 = $"{zeros}{num2}";
            }
        }

        num1 = new string(num1.Reverse().ToArray());
        num2 = new string(num2.Reverse().ToArray());

        string sum = string.Empty;
        int leftDigit = 0;
        for (int i = 0; i < maxLength; i++)
        {
            int digitNum1 = num1[i] - '0';
            int digitNum2 = num2[i] - '0';

            string sumDigits = (digitNum1 + digitNum2 + leftDigit).ToString();

            leftDigit = 0;
            if (sumDigits.Length == 1 || i == maxLength - 1)
            {
                sum = sumDigits + sum;
            }
            else
            {
                leftDigit = sumDigits[0] - '0';
                int rightDigit = sumDigits[1] - '0';
                sum = rightDigit + sum;
            }
        }

        Console.WriteLine(sum);
    }
}
