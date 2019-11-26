using System;


class Program
{
    static void Main(string[] args)
    {
        int gamesLost = int.Parse(Console.ReadLine());
        decimal headsetPrice = decimal.Parse(Console.ReadLine());
        decimal mousePrice = decimal.Parse(Console.ReadLine());
        decimal keyboardPrice = decimal.Parse(Console.ReadLine());
        decimal displayPrice = decimal.Parse(Console.ReadLine());

        int brokenHeadsets = 0;
        int brokenMice = 0;
        int brokenKeyboards = 0;
        int brokenDisplays = 0;

        for (int i = 1; i <= gamesLost; i++)
        {
            if (i % 2 == 0)
            {
                brokenHeadsets++;
            }
            if (i % 3 == 0)
            {
                brokenMice++;
            }
            if (i % 2 == 0 && i % 3 == 0)
            {
                brokenKeyboards++;
            }
        }

        for (int i = 1; i <= brokenKeyboards; i++)
        {
            if (i % 2 == 0)
            {
                brokenDisplays++;
            }
        }

        decimal sum = headsetPrice * brokenHeadsets + mousePrice * brokenMice + keyboardPrice * brokenKeyboards + brokenDisplays * displayPrice;

        Console.WriteLine($"Rage expenses: {sum:f2} lv.");
    }
}