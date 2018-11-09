using System;
using System.Collections.Generic;

namespace ParkingFeud
{
    class ParkingFeud
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<string> result = new List<string>();
            for (int i = 0; i < N; i++)
            {
                string ROW = Console.ReadLine();
                if (ROW.Contains("0"))
                {
                    ROW = ROW.Replace("0", "-");
                    result.Add(ROW);
                }
                else
                {
                    result.Add(ROW);
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
