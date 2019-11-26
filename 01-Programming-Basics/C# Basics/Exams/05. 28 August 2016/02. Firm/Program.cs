using System;

namespace _02.Firm
{
    class Program
    {
        static void Main()
        {
            int hours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workersWorksMore = int.Parse(Console.ReadLine());

            double workHours = days * 0.9 * 8;
            int hoursPlus = workersWorksMore * 2 * days;
            double hoursTotal = Math.Floor(workHours + hoursPlus);

            double diff = Math.Abs(hours - hoursTotal);

            if (hoursTotal >= hours)
            {
                Console.WriteLine($"Yes!{diff} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{diff} hours needed.");
            }
        }
    }
}
