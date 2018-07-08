using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var colSize = n / 2;
        var midSize = 2 * n - 2 * colSize - 4;

        Console.WriteLine("/{0}\\{1}/{0}\\", new string('^', colSize), new string('_', midSize));

        for (int i = 0; i < n - 3; i++)
        {
            Console.WriteLine("|{0}|", new string(' ', n * 2 - 2));
        }

        Console.WriteLine("|{0}{1}{0}|", new string(' ', colSize + 1), new string('_', midSize));

        Console.WriteLine("\\{0}/{1}\\{0}/", new string('_', colSize), new string('_', midSize));
    }
}
