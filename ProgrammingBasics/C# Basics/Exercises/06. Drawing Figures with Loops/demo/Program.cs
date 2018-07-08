using System;

namespace demo
{
    class Program
    {
        static void Main()
        {
            int a = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                string stars = new string('*', 4 + a);
                string dashes = new string('-', 2 - b);
                a++;
                b++;
                Console.WriteLine("{0}{1}{0}", stars, dashes);
            }
        }
    }
}
