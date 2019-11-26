using System;
using System.Linq;

class MultiplyBigNumber
{
    static void Main()
    {
        string bigNum = Console.ReadLine().TrimStart('0').Trim();
        int smallNum = int.Parse(Console.ReadLine());

        if (smallNum == 0 || bigNum == string.Empty)
        {
            Console.WriteLine(0);
            return;
        }

        bigNum = new string(bigNum.Reverse().ToArray());

        string product = string.Empty;
        int leftDigit = 0;
        for (int i = 0; i < bigNum.Length; i++)
        {
            int digit = bigNum[i] - '0';
            string multiplyDigits = (smallNum * digit + leftDigit).ToString();

            leftDigit = 0;
            if (multiplyDigits.Length == 1 || i == bigNum.Length - 1)
            {
                product = multiplyDigits + product;
            }
            else
            {
                leftDigit = multiplyDigits[0] - '0';
                int rightDigit = multiplyDigits[1] - '0';
                product = rightDigit + product;
            }
        }

        Console.WriteLine(product);
    }
}
