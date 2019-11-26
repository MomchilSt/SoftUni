using System;

class Program
{
    static void Main()
    {
        string month = Console.ReadLine();
        int nights = int.Parse(Console.ReadLine());
        

        double studioPrice = 0;
        double doublePrice = 0;
        double suitePrice = 0;


        switch (month)
        {
            case "May":
            case "October":
                studioPrice = 50;
                doublePrice = 65;
                suitePrice = 75;
                break;

            case "June":
            case "September":
                studioPrice = 60;
                doublePrice = 72;
                suitePrice = 82;
                break;

            case "July":
            case "August":
            case "December":
                suitePrice = 68;
                doublePrice = 77;
                suitePrice = 89;
                break;
        }

        if (month == "May" || month == "October" && nights > 7)
        {
            Console.WriteLine($"Studio: {((studioPrice - (studioPrice * 0.05)) * nights):f2} lv.");
            Console.WriteLine($"Double: {(doublePrice * nights):f2} lv.");
            Console.WriteLine($"Suite: {(suitePrice * nights):f2} lv.");

        }
        else if (month == "May" || month == "October")
        {
            Console.WriteLine($"Studio: {(studioPrice * nights):f2} lv.");
            Console.WriteLine($"Double: {(doublePrice * nights):f2} lv.");
            Console.WriteLine($"Suite: {(suitePrice * nights):f2} lv.");
        }
        if (month == "June" || month == "September" && nights > 14)
        {
            if (month == "September" && nights > 7 && nights <= 14)
            {
                Console.WriteLine($"Studio: {(studioPrice * nights):f2} lv.");
                Console.WriteLine($"Double: {((doublePrice - (doublePrice * 0.10)) * nights):f2} lv.");
                Console.WriteLine($"Suite: {(suitePrice * nights):f2} lv.");
            }
            Console.WriteLine($"Studio: {(studioPrice * nights):f2} lv.");
            Console.WriteLine($"Double: {((doublePrice - (doublePrice * 0.10)) * nights):f2} lv.");
            Console.WriteLine($"Suite: {(suitePrice * nights):f2} lv.");
        }
        else if (month == "June" || month == "September")
        {
            Console.WriteLine($"Studio: {(studioPrice * nights):f2} lv.");
            Console.WriteLine($"Double: {(doublePrice * nights):f2} lv.");
            Console.WriteLine($"Suite: {(suitePrice * nights):f2} lv.");
        }
        if (month == "July" || month == "August" || month == "December" && nights > 14)
        {
            Console.WriteLine($"Studio: {(studioPrice * nights):f2} lv.");
            Console.WriteLine($"Double: {(doublePrice * nights):f2} lv.");
            Console.WriteLine($"Suite: {((suitePrice - (suitePrice - 0.15)) * nights):f2} lv.");
        }
        else if (month == "July" || month == "August" || month == "December")
        {
            Console.WriteLine($"Studio: {(studioPrice * nights):f2} lv.");
            Console.WriteLine($"Double: {(doublePrice * nights):f2} lv.");
            Console.WriteLine($"Suite: {(suitePrice * nights):f2} lv.");
        }
    }
}
