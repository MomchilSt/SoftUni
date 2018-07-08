using System;

class DrawFort
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string carets = new string('^', n / 2);
        int underscoreFormula = n * 2 - 4 - 2 * (n / 2);
        string underscore = new string('_', underscoreFormula);
        string middleSpaces = new string(' ', n * 2 - 2);

        // Print first row
        Console.WriteLine(@"/{0}\{1}/{0}\", carets, underscore);

        // Print the middle rows
        for (int i = 0; i < n - 3; i++)
        {
            Console.WriteLine("|{0}|", middleSpaces);
        }

        // Print the low middle row
        string lowSpaces = new string(' ', (n * 2 - underscoreFormula - 2) / 2);
        Console.WriteLine("|{0}{1}{0}|", lowSpaces, underscore);

        // Print last row
        Console.WriteLine(@"\{0}/{1}\{0}/", new string('_', n / 2), new string(' ', underscoreFormula));

    }
    // n = 3          n = 4            n = 5                 n = 8 
    //           
    // /^\/^\        /^^\/^^\        /^^\__/^^\         /^^^^\____/^^^^\
    // |    |        |      |        |        |         |              |
    // \_/\_/        |      |        |        |         |              |
    //               \__/\__/        |   __   |         |              |
    //                               \__/  \__/         |              |
    //                                                  |              |
    //                                                  |     ____     |
    //                                                  \____/    \____/
}
