using System;

namespace _01.Money
{
    class Program
    {
        static void Main()
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double yuan = double.Parse(Console.ReadLine());
            double cut = double.Parse(Console.ReadLine());

            int bitcoinToLv = bitcoins * 1168;
            double yuanToLv = yuan * 0.15 * 1.76;

            double moneyEU = (bitcoinToLv + yuanToLv) / 1.95;
            double moneyTotal = moneyEU - (cut / 100) * moneyEU;

            Console.WriteLine(moneyTotal);
        }
    }
}
