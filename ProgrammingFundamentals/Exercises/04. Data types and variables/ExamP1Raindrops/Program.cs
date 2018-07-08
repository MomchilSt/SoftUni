using System;

class Program
{
    static void Main()
    {
        string[] tokens = Console.ReadLine().Split();

        int a = int.Parse(tokens[0]);
        int b = int.Parse(tokens[1]);

        Console.WriteLine(a + " " + b);

    }
}
