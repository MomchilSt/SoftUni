using System;

class Program
{
    static void Main()
    {
        string proffession = Console.ReadLine();
        int quantity = int.Parse(Console.ReadLine());

        if (proffession == "Athlete")
        {
            Console.WriteLine($"The Athlete has to pay {(quantity * 0.70):f2}.");
        }
        else if (proffession == "Businessman" || proffession == "Businesswoman")
        {
            Console.WriteLine($"The {proffession} has to pay {(quantity * 1.00):f2}.");
        }
        else if (proffession == "SoftUni Student")
        {
            Console.WriteLine($"The SoftUni Student has to pay {(quantity * 1.70):f2}.");
        }
        else
        {
            Console.WriteLine($"The {proffession} has to pay {(quantity * 1.20):f2}.");
        }
    }
}
