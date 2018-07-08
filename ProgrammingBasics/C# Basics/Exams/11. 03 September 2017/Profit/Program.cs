using System;

class Program
{
    static void Main()
    {
        int oneBGN = int.Parse(Console.ReadLine());
        int twoBGN = int.Parse(Console.ReadLine());
        int fiveBGN = int.Parse(Console.ReadLine());
        int sum = int.Parse(Console.ReadLine());

       

        for (int m1 = 0; m1 <= oneBGN; m1++)
        {
            
            for (int m2 = 0; m2 <= twoBGN; m2++)
            {

                for (int m3 = 0; m3 <= fiveBGN; m3++)
                {
                    if ((m1 * 1) + (m2 * 2) + (m3 * 5) == sum)
                    {
                        Console.WriteLine($"{m1} * 1 lv. + {m2} * 2 lv. + {m3} * 5 lv. = {sum} lv.");
                    }
                }
            }
        }
    }
}
