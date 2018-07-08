using System;

namespace _3.OnTimeForTheExam
{
    class Program
    {
        static void Main()
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minExam = int.Parse(Console.ReadLine());
            int hourCome = int.Parse(Console.ReadLine());
            int minCome = int.Parse(Console.ReadLine());

            int timeExam = minExam + hourExam * 60;
            int timeCome = minCome + hourCome * 60;
            int comingDiff = timeExam - timeCome;
            int comingDiffHours = 0;
            int comingDiffMins = 0;

            if (comingDiff >= 60 || comingDiff <= -60)
            {
                comingDiffHours = Math.Abs(comingDiff / 60);
                comingDiffMins = Math.Abs(comingDiff % 60);
            }

            if (comingDiff < 0)
            {
                Console.WriteLine("Late");
                if (comingDiff > -60)
                {
                    Console.WriteLine("{0} minutes after the start",
                                            Math.Abs(comingDiff));
                }
                else if (comingDiff <= -60)
                {
                    Console.WriteLine("{0}:{1:00} hours after the start", 
                                         Math.Abs(comingDiffHours), 
                                         Math.Abs(comingDiffMins));
                }
            }
            else if (comingDiff >= 0 && comingDiff <= 30)
            {
                Console.WriteLine("On time");
                if (comingDiff < 60 && comingDiff > 0)
                {
                    Console.WriteLine("{0} minutes before the start", 
                                            Math.Abs(comingDiff));
                }
            }
            else if (comingDiff > 30)
            {
                Console.WriteLine("Early");
                if (comingDiff < 60)
                {
                    Console.WriteLine("{0} minutes before the start", 
                                        Math.Abs(comingDiff));
                }
                else if (comingDiff >= 60)
                {
                    Console.WriteLine("{0}:{1:00} hours before the start",
                                          Math.Abs(comingDiffHours),
                                          Math.Abs(comingDiffMins));
                }
            }
        }
    }
}
