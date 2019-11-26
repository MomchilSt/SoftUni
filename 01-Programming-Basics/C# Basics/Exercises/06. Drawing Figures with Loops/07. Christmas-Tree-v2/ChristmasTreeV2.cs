using System;

class ChristmasTreeV2
{
    static void Main()
    {
        while (true)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i++)
            {
                string stars = new string('*', i);
                string spaces = new string(' ', n - i);
                string line = " | ";
                Console.WriteLine("{0}{1}{2}{1}", spaces, stars, line);
            }
        }
    }
}
