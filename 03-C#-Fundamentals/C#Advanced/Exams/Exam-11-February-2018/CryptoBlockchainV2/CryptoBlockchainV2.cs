using System;
using System.Linq;
using System.Text.RegularExpressions;

class CryptoBlockchainV2
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string sequance = string.Empty;

        string pattern = @"{[^{}\[\]]*?(\d{3,})[^{}\[\]]*?}|\[[^\]\[{}]*?(\d{3,})[^\[\]{}]*?]";
        string result = "";

        for (int i = 0; i < n; i++)
        {
            sequance += Console.ReadLine();
        }

        var matches = Regex.Matches(sequance, pattern);

        foreach (Match match in matches)
        {
            if (match.Groups[1].Value.Length % 3 == 0)
            {
                string currMatch = match.Groups[1].Value;
                int matchLenght = match.Groups[0].Value.Length;
                string currNum = "";

                for (int i = 0; i < currMatch.Length; i++)
                {
                    currNum += currMatch[i];

                    if (currNum.Length == 3)
                    {
                        int parsedNum = int.Parse(currNum);
                        result += (char)(parsedNum - matchLenght);
                        currNum = "";
                    }
                }
            }

            if (match.Groups[2].Value.Length % 3 == 0)
            {
                string currMatch = match.Groups[2].Value;
                int matchLenght = match.Groups[0].Value.Length;
                string currNum = "";

                for (int i = 0; i < currMatch.Length; i++)
                {
                    currNum += currMatch[i];

                    if (currNum.Length == 3)
                    {
                        int parsedNum = int.Parse(currNum);
                        result += (char)(parsedNum - matchLenght);
                        currNum = "";
                    }
                }
            }
        }

        Console.WriteLine(result);
    }
}