using System;

class Program
{
    static void Main()
    {
        string season = Console.ReadLine().ToLower();
        string groupType = Console.ReadLine().ToLower();
        int students = int.Parse(Console.ReadLine());
        int nights = int.Parse(Console.ReadLine());

        //double girlsGroup = 0;
        //double boysGroup = 0;
        //double mixedGroup = 0;
        double total = 0;
        string sport = string.Empty;

        switch (season)
        {
            case "winter":
                if (groupType == "girls")
                {
                    total = students * 9.60 * nights;
                    sport = "Gymnastics";
                }
                else if (groupType == "boys")
                {
                    total = students * 9.60 * nights;
                    sport = "Judo";
                }
                else
                {
                    total = students * 10 * nights;
                    sport = "ski";
                }
                break;
//--------------------------------------------------------------
            case "spring":
                if (groupType == "girls")
                {
                    total = students * 7.20 * nights;
                    sport = "Athletics";
                }
                else if (groupType == "boys")
                {
                    total = students * 7.20 * nights;
                    sport = "Tennis";
                }
                else
                {
                    total = students * 9.50 * nights;
                    sport = "Cycling";
                }
                break;
//-------------------------------------------------
            case "summer":
                if (groupType == "girls")
                {
                    total = students * 15 * nights;
                    sport = "Volleyball";
                }
                else if (groupType == "boys")
                {
                    total = students * 15 * nights;
                    sport = "Football";
                }
                else
                {
                    total = students * 20 * nights;
                    sport = "Swimming";
                }
                break;
        }

        if (students >= 10 && students < 20)
        {
            total = total - (total * 0.05);
            Console.WriteLine($"{sport} {(total):f2} lv.");
        }
        else if (students >= 20 && students < 50)
        {
            total = total - (total * 0.15);
            Console.WriteLine($"{sport} {(total):f2} lv.");
        }
        else if (students >= 50)
        {
            total = total - (total * 0.50);
            Console.WriteLine($"{sport} {(total):f2} lv.");
        }
        else
        {
            Console.WriteLine($"{sport} {(total):f2} lv.");
        }
    }
}
