using System;

namespace TimePlus15Minutes
{
    class Program
    {
        static void Main()
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes = minutes + 15;

            if (minutes > 59)
            {
                hours += 1;
                minutes -= 60;
            }
            else if (hours > 23)
            {
                hours -= hours;
            }
            Console.WriteLine("{0}:{1:D2}", hours, minutes);
        }
    }
}