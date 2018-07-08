using System;

class Program
{
    static void Main()
    {
        string proffession = Console.ReadLine();
        int quantity = int.Parse(Console.ReadLine());


        if (proffession == "Athlete")
        {
            Console.WriteLine($"The {proffession} has to pay {(0.70 * quantity):f2}.");
        }
        else if (proffession == "Businessman" || proffession == "Businesswoman")
        {
            Console.WriteLine($"The {proffession} has to pay {(1.00 * quantity):f2}.");
        }
        else if (proffession == "SoftUni Student")
        {
            Console.WriteLine($"The {proffession} has to pay {(1.70 * quantity):f2}.");
        }
        else
        {
            Console.WriteLine($"The {proffession} has to pay {(1.20 * quantity):f2}.");
        }
    }
}
