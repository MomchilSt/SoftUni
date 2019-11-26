using System;


class Diamond
{
    static void Main()
    {
        Console.WriteLine("Input a number:");

        int n = int.Parse(Console.ReadLine());

        string topDashes = new string('-', (n - 1) / 2);

        // Check is n = 1.
        if (n == 1)
        {
            Console.WriteLine("*");
            return;
        }

        // Check is n = 2.
        if (n == 2)
        {
            Console.WriteLine("**");
            return;
        }

        // Print first/last row.
        if (n % 2 == 0)
        {
            Console.WriteLine("{0}**{0}", topDashes);
        }
        else
        {
            Console.WriteLine("{0}*{0}", topDashes);
        }

        // Print top middle row/rows
        for (int i = (n - 1) / 2 - 1; i > 0; i--)
        {
            int outsideDashesCounter = i;

            string insideDashes = new string('-', n - outsideDashesCounter * 2 - 2);
            string outsideDashes = new string('-', outsideDashesCounter);

            Console.WriteLine("{0}*{1}*{0}", outsideDashes, insideDashes);
        }

        // Print the middle row.
        Console.WriteLine("*{0}*", new string('-', n - 2));

        // Print low middle row/rows
        for (int i = 0; i < (n - 1) / 2 - 1; i++)
        {
            int outsideDashesCounter = i + 1;

            string outsideDashes = new string('-', outsideDashesCounter);
            string insideDashes = new string('-', n - outsideDashesCounter * 2 - 2);

            Console.WriteLine("{0}*{1}*{0}", outsideDashes, insideDashes);
        }

        // Print first/last row.
        if (n % 2 == 0)
        {
            Console.WriteLine("{0}**{0}", topDashes);
        }
        else
        {
            Console.WriteLine("{0}*{0}", topDashes);
        }
    }

    // n = 5          n = 6          n = 7
    //
    // --*--          --**--        ---*---
    // -*-*-          -*--*-        --*-*--
    // *---*          *----*        -*---*-
    // -*-*-          -*--*-        *-----*
    // --*--          --**--        -*---*-
    //                              --*-*--
    //                              ---*---
}