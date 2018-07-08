using System;

class Program
{
    static void Main()
    {
        double miles = double.Parse(Console.ReadLine());

        double covertToKm = miles * 1.60934;

        Console.WriteLine("{0:f2}", covertToKm);
    }
}
