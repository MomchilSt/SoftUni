using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        decimal totalPrice = 0;
        for (int i = 0; i < n; i++)
        {
            decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
            DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            decimal capsulesCount = decimal.Parse(Console.ReadLine());

            decimal price = (DateTime.DaysInMonth(orderDate.Year, orderDate.Month) * capsulesCount) * pricePerCapsule;
            totalPrice += price;

            Console.WriteLine($"The price for the coffee is: ${price:F2}");
        }

        Console.WriteLine($"Total: ${totalPrice:F2}");
    }
}
