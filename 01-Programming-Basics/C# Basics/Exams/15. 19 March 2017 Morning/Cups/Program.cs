using System;

class Program
{
    static void Main()
    {
        int cups = int.Parse(Console.ReadLine());
        int workers = int.Parse(Console.ReadLine());
        int workDays = int.Parse(Console.ReadLine());

        int workingHours = (workers * workDays) * 8;
        int cupsMade = workingHours / 5;

        if (cupsMade >= cups)
        {
            Console.WriteLine($"{((cupsMade - cups)* 4.2):f2} extra money");
        }
        else
        {
            Console.WriteLine($"Losses: {((cups - cupsMade) * 4.2):f2}");
        }
    }
}
