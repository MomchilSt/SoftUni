using System;

class Program
{
    static void Main()
    {
        int months = int.Parse(Console.ReadLine());

        double electricity = 0;
        double water = 20;
        double internet = 15;
        double other = 0;

        for (int i = 0; i < months; i++)
        {
            double userInput = double.Parse(Console.ReadLine());

            electricity += userInput;
            other += userInput;

        }

        other = (other + (months * 20) + (months * 15)) * 1.20;
        double average = (electricity + (water * months) + (internet * months) + other) / months;

        Console.WriteLine($"Electricity: {electricity:f2} lv");
        Console.WriteLine($"Water: {(months * water):f2} lv");
        Console.WriteLine($"Internet: {(months * internet):f2} lv");
        Console.WriteLine($"Other: {(other):f2} lv");
        Console.WriteLine($"Average: {average:f2} lv");
    }
}
