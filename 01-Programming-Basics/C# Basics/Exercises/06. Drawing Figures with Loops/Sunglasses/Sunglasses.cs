using System;

class Sunglasses
{
    static void Main()
    {
        Console.WriteLine("Input number between 1 && 20");
        while (true)
        {
            int n = int.Parse(Console.ReadLine());

            string edges = new string('*', n * 2);
            string spaces = new string(' ', n);
            string star = "*";
            string slash = new string('/', n * 2 - 2);
            string line = new string('|', n);

            Console.WriteLine("{0}{1}{0}", edges, spaces);

            for (int i = 0; i < n - 2; i++)
            {
                if (i == (n - 1) / 2 - 1)
                {
                    spaces = line;
                }
                Console.WriteLine("{0}{1}{0}{2}{0}{1}{0}", star, slash, spaces);
                spaces = new string(' ', n);
            }

            Console.WriteLine("{0}{1}{0}", edges, spaces);

        }
    }
}
