using System;

class EnterEvenNumber
{
    static void Main()
    {
        while (true)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());

                while (n % 2 != 0)
                {
                    Console.WriteLine("Invalid number!");
                    n = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Even number entered: {0}", n);
                return;
            }
            catch
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
