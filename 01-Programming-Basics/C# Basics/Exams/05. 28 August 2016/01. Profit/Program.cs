using System;

namespace _1.Profit
{
    class Program
    {
        static void Main()
        {
            int workDays = int.Parse(Console.ReadLine());
            double profitPerDay = double.Parse(Console.ReadLine());
            double dollar = double.Parse(Console.ReadLine());

            double monthSalary = workDays * profitPerDay;
            double yearSalary = monthSalary * 12 + monthSalary * 2.5;
            double cut = yearSalary * 0.75;
            double toDollars = cut * dollar;
            double averageSalaryPerDay = toDollars / 365;

            Console.WriteLine($"{averageSalaryPerDay:f2}");
        }
    }
}
