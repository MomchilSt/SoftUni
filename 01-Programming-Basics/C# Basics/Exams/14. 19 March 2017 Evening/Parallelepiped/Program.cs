using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 3 * n + 1;

        //first row
        Console.WriteLine("+{0}+{1}", new string('~', n - 2), new string('.', width - (n -2) -2  ));

        //first section

        for (int i = 0; i < n * 2 + 1; i++)
        {
            Console.WriteLine(@"|{0}\{1}\{2}", 
                new string('.', i),
                new string('~', n - 2),
                new string('.', ((width - 3) - (n -2)) -i  )   );
        }

        //second section
    
        for (int i = 0; i < n*2 + 1; i++)
        {
            Console.WriteLine(@"{0}\{1}|{2}|",
                new string('.', i),
                new string('.', ((width - 3) - i) - (n - 2)),
                new string('~', n - 2));
        }

        //last row
        Console.WriteLine("{0}+{1}+", new string('.', (width - 2) - (n - 2)), new string('~', n - 2));

    }
}
