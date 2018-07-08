using System;

namespace task09_Count_the_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            try
            {

                while (true)
                {

                    int integer = int.Parse(Console.ReadLine());
                    counter++;
                }
            }
            catch (Exception)
            {

                Console.WriteLine(counter);
            }
        }
    }
}