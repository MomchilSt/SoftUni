using System;

namespace _5.DrawFort
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string carets = new string('^', n / 2);
            string underscores = new string('_', (n * 2) - 4 - (n / 2) * 2);

            Console.WriteLine(@"/{0}\{1}/{0}\", carets, underscores);

            for (int i = 0; i < n - 3; i++)
            {
                Console.WriteLine("|{0}|", new string(' ', n * 2 - 2));
            }
            Console.WriteLine("|{0}{1}{0}|", new string(' ', n / 2 + 1),
                                             underscores);

            Console.WriteLine(@"\{0}/{1}\{0}/", new string('_', n / 2),
                                                new string(' ', (n * 2) - 4 - (n / 2) * 2));
                                                
        }
    }
}
