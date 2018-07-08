using System;

class Program
{
    static void Main()
    {
        char firstChar = char.Parse(Console.ReadLine());
        char secondChar = char.Parse(Console.ReadLine());
        char skipChar = char.Parse(Console.ReadLine());

        for (int m1 = firstChar; m1 <= secondChar; m1++)
        {

            for (int m2 = firstChar; m2 <= secondChar; m2++)
            {

                for (int m3 = firstChar; m3 <= secondChar; m3++)
                {
                    if (m1 != skipChar && m2 != skipChar && m3 != skipChar)
                    {
                        Console.Write($"{(char)m1}{(char)m2}{(char)m3} ");
                    }
                }
            }
        }
    }
}
