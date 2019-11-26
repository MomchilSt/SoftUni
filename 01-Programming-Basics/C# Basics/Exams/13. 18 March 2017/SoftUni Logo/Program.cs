using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 12 * n - 5;
        int firstDots = (width - 1) / 2;
        int cycleDots = (width - 7) / 2;

        Console.WriteLine("{0}#{0}", new string('.', (width - 1) / 2));

        for (int i = 0; i < 2*n - 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', cycleDots), new string('#', 7 + (i * 3) * 2));
            cycleDots -= 3;
        }

        Console.WriteLine(new string('#', width));

        int firstDost = 2;
        int secondDots = 3;
        int mid = width - (firstDost + secondDots + 1);

        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("|{0}{1}{2}", new string('.', firstDost), new string('#', mid ),
                new string('.', secondDots));
            firstDost += 3;
            secondDots += 3;
            mid -= 6;

        }

        

        for (int i = 1; i <= n; i++)
        {

            if (!(i == n))
            {
                Console.WriteLine("|{0}{1}{2}", new string('.', firstDost), new string('#', mid),
                new string('.', secondDots));
            }
            else
            {
                Console.WriteLine("@{0}{1}{2}", new string('.', firstDost), new string('#', mid),
                new string('.', secondDots));
            }
        }
    }
}
