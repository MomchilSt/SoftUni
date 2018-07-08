using System;

class CharacterMultiplier
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        char[] chars1 = input[0].ToCharArray();
        char[] chars2 = input[1].ToCharArray();

        int product = MultiplyChars(chars1, chars2);

        Console.WriteLine(product);
    }

    private static int MultiplyChars(char[] chars1, char[] chars2)
    {
        int minLength = Math.Min(chars1.Length, chars2.Length);
        int maxLength = Math.Max(chars1.Length, chars2.Length);

        int result = 0;
        for (int i = 0; i < minLength; i++)
        {
            result += chars1[i] * chars2[i];
        }
        for (int i = minLength; i < maxLength; i++)
        {
            if (chars1.Length == maxLength)
            {
                result += chars1[i];
            }
            else
            {
                result += chars2[i];
            }
        }

        return result;
    }
}
