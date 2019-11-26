using System;

class Program                   //n=6 mid = 3x6          n=8 mid 3x8
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 5 * n;
        int mid = n * 3;
        int leftAndRight = (width - mid) / 2;

        for (int i = 0; i < n / 2; i++)
        {
            //Console.WriteLine("{0}{1}{0}", new string('.', leftAndRight + i), new string('#', mid - i));
            Console.Write(new string('.', leftAndRight + i));
            Console.Write(new string('#', mid));
            Console.WriteLine(new string('.', leftAndRight + i));
            mid -= 2;            
        }

        int counter = (width - (mid + 2)) / 2;
        for (int i = 0; i < n / 2 + 1; i++)
        {
            mid -= 2;
            Console.Write(new string('.', counter + i + 1));
            Console.Write("#{0}#",new string('.', mid));
            Console.WriteLine(new string('.', counter + i + 1));
        }

        Console.WriteLine("{0}{1}{0}", new string('.', (width - n) / 2), new string('#', n));

        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', (width - (n+4)) / 2), new string('#', n + 4));
        }

        Console.WriteLine("{0}D^A^N^C^E^{0}", new string('.', (width - 10) / 2));

        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', (width - (n + 4)) / 2), new string('#', n + 4));
        }

        Console.WriteLine("{0}{1}{0}", new string('.', (width - (n + 4)) / 2), new string('#', n + 4));
    }
}
