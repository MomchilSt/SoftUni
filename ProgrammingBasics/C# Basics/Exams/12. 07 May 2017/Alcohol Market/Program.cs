using System;

class Program
{
    static void Main()
    {
        double whiskeyPricePerLeter = double.Parse(Console.ReadLine());
        double beerQuantity = double.Parse(Console.ReadLine());
        double wineQuantity = double.Parse(Console.ReadLine());
        double rakiaQuantity = double.Parse(Console.ReadLine());
        double whiskeyQuantity = double.Parse(Console.ReadLine());

        double rakiaPricePerLeter = whiskeyPricePerLeter / 2.0;
        double winePricePerLeter = rakiaPricePerLeter * 0.6;
        double beerPricePerLeter = rakiaPricePerLeter * 0.2;

        double rakiaPrice = rakiaPricePerLeter * rakiaQuantity;
        double winePrice = winePricePerLeter * wineQuantity;
        double beerPrice = beerPricePerLeter * beerQuantity;
        double whiskeyPrice = whiskeyPricePerLeter * whiskeyQuantity;

        double totalPrice = rakiaPrice + winePrice + beerPrice + whiskeyPrice;
        Console.WriteLine("{0:0.00}", totalPrice);
    }
}
