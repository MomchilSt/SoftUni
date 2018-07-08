using System;
using System.Collections.Generic;

class ConsoleCurrencyCalculatorV2
{
    static void Main()
    {
        var moneyToConvert = decimal.Parse(Console.ReadLine());
        string firstCurrency = Console.ReadLine();
        string secondCurrency = Console.ReadLine();

        var currencies = new Dictionary<string, decimal>()
        {
            {"BGN", 1},
            {"USD", 1.79549m},
            {"EUR", 1.95583m},
            {"GBP", 2.53405m}
        };

        var result = (moneyToConvert * currencies[firstCurrency]) / currencies[secondCurrency];
        Console.WriteLine(Math.Round(result, 2) + " {0}", secondCurrency);

        //1 BGN = 1.79549 USD
        //1 BGN = 1.95583 EUR
        //1 BGN = 2.53405 GBP
    }
}
