using System;

class P1DayOfWeek
{
    static void Main(string[] args)
    {
        string[] daysNames = 
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursdays",
            "Friday",
            "Saturday",
            "Sunday"
        };

        int day = int.Parse(Console.ReadLine());

        if (day >= 1 && day <= 7)
        {
            string daysInEnglish = daysNames[day - 1];
            Console.WriteLine(daysInEnglish);
        }
        else
        {
            Console.WriteLine("Invalid Day!");
        }
    }
}

