using System;

namespace _04.Hospital
{
    class Program
    {
        static void Main()
        {
            int time = int.Parse(Console.ReadLine());

            int doctors = 7;
            int treated = 0;
            int untreated = 0;

            for (int i = 1; i <= time; i++)
            {
                int patients = int.Parse(Console.ReadLine());

                if (i % 3 == 0 && untreated > treated)
                    doctors++;

                if (patients <= doctors)
                    treated += patients;
                else
                {
                    treated += doctors;
                    untreated += patients - doctors;
                }
            }

            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");
        }
    }
}
