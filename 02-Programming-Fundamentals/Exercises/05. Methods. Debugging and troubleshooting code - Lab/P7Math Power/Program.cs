using System;

class P7MathPower
{
    static void Main()
    {
        double number = double.Parse(Console.ReadLine());
        int power = int.Parse(Console.ReadLine());
        double result = RaiseToPower(number, power);
        Console.WriteLine(result);
    }

    static double RaiseToPower(double number, int power)
    {
        double result = 0d;
        result = Math.Pow(number, power);
        return result;
    }
}
