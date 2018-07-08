using System;

class Program
{
    static void Main()
    {
        int tables = int.Parse(Console.ReadLine());
        double tableLenght = double.Parse(Console.ReadLine());
        double tableWidth = double.Parse(Console.ReadLine());

        double fullArea = tables * (tableLenght + 2 * 0.30) * (tableWidth + 2 * 0.30);
        double caresArea = tables * (tableLenght / 2) * (tableLenght / 2);

        double prizeUSD = fullArea * 7 + caresArea * 9;
        double prizeBGN = prizeUSD * 1.85;

        Console.WriteLine($"{prizeUSD:f2} USD");
        Console.WriteLine($"{prizeBGN:f2} BGN");
    }
}
