using System;

namespace _4.Grades
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int top = 0;
            int veryGood = 0;
            int good = 0;
            int fail = 0;
            double average = 0;

            for (int i = 0; i < n; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                average += grade;
                if (grade < 3) { fail++; }
                else if (grade < 4) { good++; }
                else if (grade < 5) { veryGood++; }
                else { top++; }
            }

            average /= n;
            double topP = (double)top / n * 100;
            double veryGoodP = (double)veryGood / n * 100;
            double goodP = (double)good / n * 100;
            double failP = (double)fail / n * 100;

            Console.WriteLine($"Top students: {topP:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {veryGoodP:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {goodP:f2}%");
            Console.WriteLine($"Fail: {failP:f2}%");
            Console.WriteLine($"Average: {average:f2}");
        }
    }
}
