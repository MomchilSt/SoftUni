using System;

namespace SongOfTheWheels
{
    class Program
    {
        static void Main()
        {
            int controlNumber = int.Parse(Console.ReadLine());  // от 4 до 144 включително
            int counter = 0;
            int password = 0;
            bool fourthNum = false;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            int neededNum = (a * b) + (c * d);

                            if (a < b && c > d && (neededNum == controlNumber))
                            {
                                Console.Write($"{a}{b}{c}{d} ");
                                counter++;

                                if (counter == 4)
                                {
                                    password = 1000 * a + 100 * b + 10 * c + d;
                                    fourthNum = true;
                                }

                            }

                        }
                    }
                }
            }

            Console.WriteLine();

            if (fourthNum == true)
            {
                Console.WriteLine("Password: {0}", password);
            }
            else
            {
                Console.WriteLine("No!");
            }
        }
    }
}