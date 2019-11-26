using System;

class SweetDessert
{
    static void Main()
    {
        double cash = double.Parse(Console.ReadLine());
        int guestsCount = int.Parse(Console.ReadLine());
        double bananaPrice = double.Parse(Console.ReadLine());
        double eggPrice = double.Parse(Console.ReadLine());
        double berriesKiloPrice = double.Parse(Console.ReadLine());

        int setsCount = guestsCount / 6;
        if (guestsCount % 6 != 0) { setsCount++; }
        double setCost = 2 * bananaPrice + 4 * eggPrice + 0.2 * berriesKiloPrice;
        double totalCost = setsCount * setCost;

        if (totalCost <= cash)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {totalCost:F2}lv.");
        }
        else if (totalCost > cash)
        {
            Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalCost - cash:F2}lv more.");
        }
    }
}
