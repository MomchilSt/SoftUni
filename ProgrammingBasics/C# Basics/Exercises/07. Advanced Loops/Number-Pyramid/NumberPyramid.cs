using System;

class NumberPyramid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int cols = 1;
        int sim = 1;

        while (true)
        {
            for (int i = 0; i < cols; i++)
            {
                Console.Write($"{sim} ");
                sim++;

                if (sim > n)
                {
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine();

            cols++;
        }
    }
}
