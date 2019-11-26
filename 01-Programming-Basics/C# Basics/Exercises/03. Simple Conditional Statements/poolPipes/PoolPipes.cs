using System;

class PoolPipes
{
    static void Main()
    {
        double V = double.Parse(Console.ReadLine());
        double P1 = double.Parse(Console.ReadLine());
        double P2 = double.Parse(Console.ReadLine());
        double H = double.Parse(Console.ReadLine());

        double filled = (P1 + P2) * H;
        double filledInPercents = (((P1 + P2) * H) / V) * 100.0;
        double pipe1Fill = ((P1 / filled) * 100.0) * H;
        double pipe2Fill = ((P2 / filled) * 100.0) * H;

        if (filled <= V)
        {
            Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.", (int)filledInPercents, (int)pipe1Fill, (int)pipe2Fill);
        }
        else
        {
            Console.WriteLine("For {0} hours the pool overflows with {1} liters.", H, filled - V);
        }
    }
}
