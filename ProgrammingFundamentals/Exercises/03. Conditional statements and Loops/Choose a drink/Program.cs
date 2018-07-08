using System;

class Program
{
    static void Main()
    {
        string proffession = Console.ReadLine().ToLower();

        if (proffession == "athlete")
        {
            Console.WriteLine("Water");
        }
        else if (proffession == "businessman" || proffession == "businesswoman")
        {
            Console.WriteLine("Coffee");
        }
        else if (proffession == "softuni student")
        {
            Console.WriteLine("Beer");
        }
        else
        {
            Console.WriteLine("Tea");
        }
    }
}
