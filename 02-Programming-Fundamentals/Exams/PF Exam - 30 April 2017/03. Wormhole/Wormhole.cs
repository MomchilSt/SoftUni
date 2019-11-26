using System;
using System.Linq;

class Wormhole
{
    static void Main()
    {
        int[] holes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int steps = 1;
        for (int i = 0; i < holes.Length; i++)
        {
            if (holes[i] == 0)
            {
                if (i != holes.Length - 1)
                {
                    steps++;
                }
            }
            else
            {
                int temp = i;
                i = holes[i] - 1;
                holes[temp] = 0;
            }
        }

        Console.WriteLine(steps);
    }
}
