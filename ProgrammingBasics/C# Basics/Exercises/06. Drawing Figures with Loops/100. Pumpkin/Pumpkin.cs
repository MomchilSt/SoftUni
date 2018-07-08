using System;

class Pumpkin
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string firstDots = new string('.', n - 1);
        string secondDots = new string('.', n - 2);

        //Print 1st row
        Console.WriteLine("{0}_/_{0}", firstDots);

        //Print 2nd row
        Console.WriteLine(@"/{0}^,^{0}\", secondDots);

        //Print middle rows
        for (int i = 0; i < n - 3; i++)
        {
            Console.WriteLine("|{0}|", new string('.', 3 + 2 * (n - 2)));
        }

        //Print last row
        Console.WriteLine(@"\{0}\_/{0}/", secondDots);

        //   n = 3            n = 4               n = 5
        //  .._/_..         ..._/_...          ...._/_....
        //  /.^,^.\         /..^,^..\          /...^,^...\
        //  \.\_/./         |.......|          |.........|
        //                  \..\_/../          |.........|
        //                                     \...\_/.../
    }
}
