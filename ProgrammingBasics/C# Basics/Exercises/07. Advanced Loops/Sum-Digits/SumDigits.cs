using System;

class SumDigits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int lastdigit = 0;
        int sum = 0;

        while (n > 0)
        {
            lastdigit = n % 10;
            sum += lastdigit;
            n = n / 10;
        }
        Console.WriteLine(sum);
    }
}
