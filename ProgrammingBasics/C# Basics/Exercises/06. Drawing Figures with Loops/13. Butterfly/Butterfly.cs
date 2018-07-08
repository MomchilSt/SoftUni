using System;

class Butterfly
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string stars = new string('*', n - 2);
        string dashes = new string('-', n - 2);

        for (int i = 0; i < (n - 2) / 2; i++)
        {
            Console.WriteLine(@"{0}\ /{0}", stars);
            Console.WriteLine(@"{0}\ /{0}", dashes);
        }
        Console.WriteLine(@"{0}\ /{0}", stars);

        Console.WriteLine("{0}@{0}", new string(' ', n - 1));

        for (int i = 0; i < (n - 2) / 2; i++)
        {
            Console.WriteLine(@"{0}/ \{0}", stars);
            Console.WriteLine(@"{0}/ \{0}", dashes);
        }
        Console.WriteLine(@"{0}/ \{0}", stars);

        // n = 3            n = 5
        //
        // *\ /*           ***\ /***
        //   @             ---\ /---
        // */ \*           ***\ /***
        //                     @
        //                 ***/ \***
        //                 ---/ \---
        //                 ***/ \***
    }
}
