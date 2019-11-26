using System;

class NumsEndingin7V2
{
    static void Main()
    {
        for (int i = 0; i <= 1000; i++)
        {
            if (i % 10 == 7)
            {
                Console.WriteLine(i);
            }
        }
    }
}
