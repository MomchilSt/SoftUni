using System;

class Program
{
    static void Main(string[] args)
    {
        int employeeOne = int.Parse(Console.ReadLine());
        int employeeTwo = int.Parse(Console.ReadLine());
        int employeeThree = int.Parse(Console.ReadLine());
        int customers = int.Parse(Console.ReadLine());
    
        int customersForHour = employeeOne + employeeTwo + employeeThree;
        int hours = 0;
        int summ = 0;

        while (true)
        {

            hours++;

            if (hours % 4 == 0)
            {
                hours++;
            }

            summ += customersForHour;

            if (customers <= summ)
            {
                break;
            }
        }
        Console.WriteLine($"Time needed: {hours}h.");
    }
}