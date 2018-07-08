using System;

class InchesToCentimeters
{
    static void Main()
    {
        Console.Write("Inches = ");
        var inch = decimal.Parse(Console.ReadLine());
        Console.Write("Centimeters = ");
        Console.WriteLine(inch * 2.54m);
    }
}
