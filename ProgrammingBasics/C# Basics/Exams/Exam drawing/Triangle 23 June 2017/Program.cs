using System;

class Program       //n=8 15  n
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = (4 * n) + 1;

        Console.WriteLine(new string('#', width));

        var dots = 1;
        var spaces = 1;
        var fill = (width - 3) / 2;             //new string('#', fill)

        for (int i = 0; i < n / 2; i++)
        {
            // Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', dots), new string('#', fill), 
            //     new string(' ', spaces));

            Console.Write(new string('.', dots));
            Console.Write(new string('#', fill ));
            Console.Write(new string(' ', spaces));
            Console.Write(new string('#', fill ));
            Console.WriteLine(new string('.', dots));
            dots++;
            spaces += 2;
            fill-=2;

        }
        Console.WriteLine("{0}{1}{2}(@){2}{1}{0}", new string('.', dots), new string('#', fill),
        new string(' ', (spaces-3) / 2));

        if (n % 2 == 0)
        {
            for (int i = 0; i < n / 2 - 1; i++)
            {
                dots += 1;
                fill -= 2;
                spaces += 2;

                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', dots), new string('#', fill),
                    new string(' ', spaces));
            }
        }
        else
        {
            for (int i = 0; i < n / 2 ; i++)
            {
                dots += 1;
                fill -= 2;
                spaces += 2;

                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', dots), new string('#', fill),
                    new string(' ', spaces));
            }
        }

        spaces++;
        var secondFill = fill + spaces;
        secondFill -= 2;
        dots++;
        for (int i = 0; i < n; i++)
        {
            //Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('#', secondFill));
            //dots += 2;
            //secondFill -= 2;
            
            Console.Write(new string('.', dots + i));
            Console.Write(new string('#', secondFill));
            Console.WriteLine(new string('.', dots + i));
            secondFill -= 2;

        }

    }
}
