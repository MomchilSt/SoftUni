using System;

class Program
{
    static void Main()
    {
        int people = int.Parse(Console.ReadLine());
        string package = Console.ReadLine().ToLower();

        double total = 0;
        string place = string.Empty;

        if (people <= 50)
        {
            total += 2500;
            place = "Small Hall";
        }
        else if (people > 50 && people <= 100)
        {
            total += 5000;
            place = "Terrace";
        }
        else if (people > 100 && people <= 120)
        {
            total += 7500;
            place = "Great Hall";
        }
        else
        {
            Console.WriteLine("We do not have an appropriate hall.");
            return;
        }

        if (package == "normal")
        {
            total += 500;
            total = total - (total * 0.05);
            Console.WriteLine($"We can offer you the {place}");
            Console.WriteLine($"The price per person is {(total / people):f2}$");
        }
        else if (package == "gold")
        {
            total += 750;
            total = total - (total * 0.10);
            Console.WriteLine($"We can offer you the {place}");
            Console.WriteLine($"The price per person is {(total / people):f2}$");
        }
        else
        {
            total += 1000;
            total = total - (total * 0.15);
            Console.WriteLine($"We can offer you the {place}");
            Console.WriteLine($"The price per person is {(total / people):f2}$");
        }
    }
}
