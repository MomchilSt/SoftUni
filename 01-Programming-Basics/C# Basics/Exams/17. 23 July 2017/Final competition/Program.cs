using System;

class Program
{
    static void Main()
    {
        int dancers = int.Parse(Console.ReadLine());
        double points = double.Parse(Console.ReadLine());
        string season = Console.ReadLine().ToLower();
        string place = Console.ReadLine().ToLower();

        double total = 0;

        switch (season)
        {
            case "summer":
                if (place == "bulgaria")
                {
                    total = points * dancers;
                    total = total - (total * 0.05);
                }
                else if (place == "abroad")
                {
                    total = (dancers * points) * 1.50;
                    total = total - (total * 0.10);
                }
                break;
                
            case "winter":
                if (place == "bulgaria")
                {
                    total = points * dancers;
                    total = total - (total * 0.08);
                }
                else if (place == "abroad")
                {
                    total = (dancers * points) * 1.50;
                    total = total - (total * 0.15);
                }
                break;
        }

        double charity = total * 0.75;
        double moneyPerPerson = (total - charity) / dancers;

        Console.WriteLine($"Charity - {charity:f2}");
        Console.WriteLine($"Money per dancer - {moneyPerPerson:f2}");
    }
}
