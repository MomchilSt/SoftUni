using System;

class ConsoleCurrencyCalculator
{
    static void Main()
    {
        var convertingMoney = double.Parse(Console.ReadLine());
        var firstCurrency = Console.ReadLine();
        var secondCurrency = Console.ReadLine();

        var firstRate = 0.0;
        var secondRate = 0.0;

        if (firstCurrency == "USD") { firstRate *= 1.79549; }
        else if (firstCurrency == "EUR") { firstRate *= 1.95583; }
        else if (firstCurrency == "GBP") { firstRate *= 2.53405; }

        if (secondCurrency == "USD") { secondRate /= 1.79549; }
        else if (secondCurrency == "EUR") { secondRate /= 1.95583; }
        else if (secondCurrency == "GBP") { secondRate /= 2.53405; }

        var result = convertingMoney * (firstRate / secondRate);
        Console.WriteLine(Math.Round(convertingMoney, 2));

        //1 BGN = 1.79549 USD
        //1 BGN = 1.95583 EUR
        //1 BGN = 2.53405 GBP
    }
}
