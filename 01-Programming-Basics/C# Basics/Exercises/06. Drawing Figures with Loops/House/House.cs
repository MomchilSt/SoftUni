using System;

class House
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string topDashesEven = new string('-', (n - 2) / 2);
        string topDashesOdd = new string('-', (n - 1) / 2);
        int starsEvenCount = 2;
        int starsOddCount = 1;
        string starsEven = new string('*', starsEvenCount);
        string starsOdd = new string('*', starsOddCount);

        string line = "|";
        string wall = new string('*', n - 2);

        if (n % 2 == 0)
        {
            Console.WriteLine("{0}{1}{0}", topDashesEven, starsEven);
        }
        else
        {
            Console.WriteLine("{0}{1}{0}", topDashesOdd, starsOdd);
        }

        for (int i = 0; i < (n - 3) / 2; i++)
        {
            string middleStarsEven = new string('*', starsEvenCount + 2);
            string middleStarsOdd = new string('*', starsOddCount + 2);
            string middleDashesEven = new string('-', (n - starsEvenCount - 1) / 2);
            string middleDashesOdd = new string('-', (n - starsOddCount - 1) / 2);

            if (n % 2 == 0)
            {
                Console.WriteLine("{0}{1}{0}", middleDashesEven, middleStarsEven);
            }
            else
            {
                Console.WriteLine("{0}{1}{0}", middleDashesOdd, middleStarsOdd);
            }
            starsEvenCount += 2;
            starsOddCount += 2;
        }

        Console.WriteLine(new string('*', n));

        for (int j = 0; j < n / 2; j++)
        {
            Console.WriteLine("{0}{1}{0}", line, wall);
        }
    }
}