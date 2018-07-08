using System;

namespace _01.Coding_101_Exam___6_March_2016
{
    class Program
    {
        static void Main()
        {
            double h = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());

            double widthArea = w * 100 - 100;
            double widthDesks = Math.Floor(widthArea / 70);
            double heightArea = h * 100;
            double heightDesks = Math.Floor(heightArea / 120);
            int result = (int)widthDesks * (int)heightDesks - 3;

            Console.WriteLine(result);
        }
    }
}
