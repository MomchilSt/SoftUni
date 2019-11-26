using System;

class TradingCuts
{
    static void Main()
    {
        string town = Console.ReadLine().ToLower();
        double s = double.Parse(Console.ReadLine());
        double cut = -1.0;

        if (town == "sofia")
        {
            if (0 <= s && s <= 500) { cut = 5 / 100.0; }
            else if (500 < s && s <= 1000) { cut = 7 / 100.0; }
            else if (1000 < s && s <= 10000) { cut = 8 / 100.0; }
            else if (s > 10000) { cut = 12 / 100.0; }
        }
        else if (town == "varna")
        {
            if (0 <= s && s <= 500) { cut = 4.5 / 100.0; }
            else if (500 < s && s <= 1000) { cut = 7.5 / 100.0; }
            else if (1000 < s && s <= 10000) { cut = 10 / 100.0; }
            else if (s > 10000) { cut = 13 / 100.0; }
        }
        else if (town == "plovdiv")
        {
            if (0 <= s && s <= 500) { cut = 5.5 / 100.0; }
            else if (500 < s && s <= 1000) { cut = 8 / 100.0; }
            else if (1000 < s && s <= 10000) { cut = 12 / 100.0; }
            else if (s > 10000) { cut = 14.5 / 100.0; }
        }

        if (cut >= 0)
        {
            Console.WriteLine("{0:f2}", s * cut);
        }
        else
        {
            Console.WriteLine("error");
        }
        // Град     0 ≤ s ≤ 500      500 < s ≤ 1 000      1 000 < s ≤ 10 000       s > 10 000
        // Sofia       5 %               7 %                     8 %                 12 %
        // Varna       4.5 %             7.5 %                   10 %                13 %
        // Plovdiv     5.5 %             8 %                     12 %                14.5 %
    }
}
