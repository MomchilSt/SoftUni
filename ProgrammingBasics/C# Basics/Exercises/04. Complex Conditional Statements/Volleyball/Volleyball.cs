using System;

class Volleyball
{
    static void Main()
    {
        string year = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        double saturdayPlays = (48 - h) * 3 / 4.0;
        double holidayPlays = p * 2 / 3.0;
        double totalPlays = saturdayPlays + h + holidayPlays;

        if (year == "leap")
        {
            double leapYearPlays = totalPlays + (totalPlays * 15 / 100.0);
            Console.WriteLine("{0}", Math.Floor(leapYearPlays));
        }
        else
        {
            Console.WriteLine("{0}", Math.Floor(totalPlays));
        }
    }
}
