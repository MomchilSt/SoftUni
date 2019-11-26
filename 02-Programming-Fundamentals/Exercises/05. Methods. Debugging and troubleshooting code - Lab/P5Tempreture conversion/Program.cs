using System;

class P5FahrenheitToCelsius
{
    static void Main()
    {
        double fahrenheit = double.Parse(Console.ReadLine());
        double celsius = FahrenheitToCelsius(fahrenheit);
        Console.WriteLine($"{celsius:f2}");
    }

    static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
}
