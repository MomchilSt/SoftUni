using System;

class Company
{
    static void Main()
    {
        int hours = int.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());
        int overtimeWorkers = int.Parse(Console.ReadLine());

        double workDays = days - 0.1 * days;
        double workHours = workDays * 8;
        int overtimeBonus = overtimeWorkers * 2 * days;
        double hoursTotal = workHours + overtimeBonus;
        hoursTotal = Math.Floor(hoursTotal);

        if (hoursTotal >= hours)
        {
            var hoursLeft = hoursTotal - hours;
            Console.WriteLine("Yes!{0} hours left.", hoursLeft);
        }
        else
        {
            var neededHours = hours - hoursTotal;
            Console.WriteLine("Not enough time!{0} hours needed.", neededHours);
        }
    }
}
