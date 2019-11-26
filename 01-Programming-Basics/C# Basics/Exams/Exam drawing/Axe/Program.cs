using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var width = 5 * n;
        var leftDashes = 3 * n;
        var middleDashes = 0;
        var rightDashes = width - leftDashes - middleDashes - 2;

        for (int i = 0; i < n ; i++)
        {
            Console.WriteLine("{0}*{1}*{2}",new string('-', leftDashes),new string('-', middleDashes),new string('-', rightDashes));

            middleDashes++;
            rightDashes -= 1;
        }

        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}*{1}*{2}", new string('*', leftDashes), new string('-', middleDashes), new string('-', rightDashes) );
        }

        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{2}", new string('-',leftDashes), new string('-', middleDashes), new string('-', rightDashes));
            middleDashes += 2;
            rightDashes -= 1;
            leftDashes -= 1;
        }

        Console.WriteLine("{0}*{1}*{2}", new string('-', leftDashes - 1), new string('*', middleDashes), new string('-', rightDashes + 1));
    }
}
