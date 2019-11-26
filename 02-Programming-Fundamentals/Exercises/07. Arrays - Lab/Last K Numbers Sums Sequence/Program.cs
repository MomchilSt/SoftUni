using System;

class Program
{
    static void Main(string[] args)
    {
        long lenght = long.Parse(Console.ReadLine());
        long count = long.Parse(Console.ReadLine());

        long[] seq = new long[lenght];
        seq[0] = 1;

        for (int i = 1; i < lenght; i++)
        {
            long sum = 0;
            int counter = 0;

            for (int j = i; j >= 0; j--)
            {
                sum += seq[j];
                counter++;
                if (counter > count)
                {
                    break;
                }
            }
            seq[i] = sum;
        }
        Console.WriteLine(string.Join(" ", seq));
    }
}
