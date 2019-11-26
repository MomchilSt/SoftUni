using System;

class TimePlus15Minutes
{
    static void Main()
    {
        int hours = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());
        minutes = minutes + 15;

        if (minutes >= 60)
        {
            minutes = minutes - 60;
            hours++;
        }
        if (hours >= 24)
        {
            hours = hours - 24;
        }
        Console.WriteLine("{0}:{1:D2}", hours, minutes);
    }
}
