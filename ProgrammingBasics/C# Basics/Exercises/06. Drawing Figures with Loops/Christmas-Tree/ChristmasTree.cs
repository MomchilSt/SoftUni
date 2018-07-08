using System;

class ChristmasTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.Write(new string(' ', n + 1));
        Console.WriteLine("|");
        for (int i = 1; i < n + 1; i++)
        {
            Console.Write(new string(' ', n - i));
            Console.WriteLine(new string('*', i) + " | " + new string('*', i));
        }
        Console.ReadLine();
    }
}
