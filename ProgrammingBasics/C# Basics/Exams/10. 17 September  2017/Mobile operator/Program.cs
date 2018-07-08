using System;

class Program
{
    static void Main()
    {
        string contractLenght = Console.ReadLine().ToLower();
        string contractSize = Console.ReadLine().ToLower();
        string internet = Console.ReadLine().ToLower();
        int months = int.Parse(Console.ReadLine());

        double prize = 0;

        switch (contractSize)
        {
            case "small":
                if (contractLenght == "one")
                {
                    if (internet == "yes")
                    {
                        prize = 9.98 + 5.50;
                        prize = prize * months;
                    }
                    else
                    {
                        prize = 9.98 * months;
                    }
                }
                else if (contractLenght == "two")
                {
                    if (internet == "yes")
                    {
                        prize = 8.58 + 5.50;
                        prize = prize * months;
                        prize = prize - (prize * 0.0375);
                    }
                    else
                    {
                        prize = 8.58 * months;
                        prize = prize - (prize * 0.0375);
                    }
                }
                break;

            //====================================================

            case "middle":
                if (contractLenght == "one")
                {
                    if (internet == "yes")
                    {
                        prize = 18.99 + 4.35;
                        prize = prize * months;
                    }
                    else
                    {
                        prize = 18.99 * months;
                    }
                }
                else if (contractLenght == "two")
                {
                    if (internet == "yes")
                    {
                        prize = 17.09 + 4.35;
                        prize = prize * months;
                        prize = prize - (prize * 0.0375);
                    }
                    else
                    {
                        prize = 17.09 * months;
                        prize = prize - (prize * 0.0375);
                    }
                }
                break;

            //================================================

            case "large":
                if (contractLenght == "one")
                {
                    if (internet == "yes")
                    {
                        prize = 25.98 + 4.35;
                        prize = prize * months;
                    }
                    else
                    {
                        prize = 25.98 * months;
                    }
                }
                else if (contractLenght == "two")
                {
                    if (internet == "yes")
                    {
                        prize = 23.59 + 4.35;
                        prize = prize * months;
                        prize = prize - (prize * 0.0375);
                    }
                    else
                    {
                        prize = 23.59 * months;
                        prize = prize - (prize * 0.0375);
                    }
                }
                break;

            //=======================================================

            case "extralarge":
                if (contractLenght == "one")
                {
                    if (internet == "yes")
                    {
                        prize = 35.99 + 3.85;
                        prize = prize * months;
                    }
                    else
                    {
                        prize = 35.99 * months;
                    }
                }
                else if (contractLenght == "two")
                {
                    if (internet == "yes")
                    {
                        prize = 31.79 + 3.85;
                        prize = prize * months;
                        prize = prize - (prize * 0.0375);
                    }
                    else
                    {
                        prize = 31.79 * months;
                        prize = prize - (prize * 0.0375);
                    }
                }
                break;

        }

        Console.WriteLine($"{prize:f2} lv.");
    }
}
