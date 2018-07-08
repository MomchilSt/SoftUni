using System;

class Program
{
    static void Main()
    {
        int people = int.Parse(Console.ReadLine());
        string package = Console.ReadLine().ToLower();

        double price = 0;
        double discount = 0.0;

        switch (package)
        {
            case "normal":
                price = 500;
                discount = 0.05;
                break;

            case "gold":
                price = 750;
                discount = 0.10;
                break;

            case "platinum":
                price = 1000;
                discount = 0.15;
                break;
        }

        if (people <= 50)
        {
            price += 2500;
            price = price - (price * discount);
            Console.WriteLine("We can offer you Small Hall");
            Console.WriteLine($"The price per person is {(price / people):f2}$");
        }
        else if (people > 50 && people <= 100)
        {
            price += 5000;
            price = price - (price * discount);
            Console.WriteLine("We can offer you Terrace");
            Console.WriteLine($"The price per person is {(price / people):f2}$");
        }
        else if (people > 100 && people <=120)
        {
            price += 7500;
            price = price - (price * discount);
            Console.WriteLine("We can offer you Great Hall");
            Console.WriteLine($"The price person is {(price / people):f2}$");
        }
        else
        {
            Console.WriteLine("We do not have an appropriate hall.");
        }
    }
}
