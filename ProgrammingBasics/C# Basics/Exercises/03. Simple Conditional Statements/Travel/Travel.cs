using System;

class Travel
{
    static void Main()
    {
        ushort n = ushort.Parse(Console.ReadLine());

        int holidays = n * 127;
        int workingDays = (365 - n) * 63;
        int playTime = holidays + workingDays;
        int hours = 0;
        int mins = 0;

        if (playTime > 30000)
        {
            hours = (playTime - 30000) / 60;
            mins = (playTime - 30000) % 60;
            Console.WriteLine("Tom will run away");
            Console.WriteLine("{0} hours and {1} minutes more for play", hours, mins);
        }
        else
        {
            hours = (30000 - playTime) / 60;
            mins = (30000 - playTime) % 60;
            Console.WriteLine("Tom sleeps well");
            Console.WriteLine("{0} hours and {1} minutes less for play", hours, mins);
        }
    }
}
