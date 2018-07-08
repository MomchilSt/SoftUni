using System;

class Program
{
    static void Main()
    {
        double priceVegetables = double.Parse(Console.ReadLine());
        double fruitsPrice = double.Parse(Console.ReadLine());
        int vegetablesKg = int.Parse(Console.ReadLine());
        int fruitsKg = int.Parse(Console.ReadLine());

        double income = priceVegetables * vegetablesKg + fruitsPrice * fruitsKg;
        income /= 1.94;
        Console.WriteLine(income);
    }
}
