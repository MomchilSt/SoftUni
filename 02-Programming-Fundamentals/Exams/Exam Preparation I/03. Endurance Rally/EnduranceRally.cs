using System;
using System.Collections.Generic;
using System.Linq;

class EnduranceRally
{
    static void Main()
    {
        string[] drivers = Console.ReadLine()
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        double[] zones = Console.ReadLine()
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => double.Parse(x))
            .ToArray();
        int[] checkpoints = Console.ReadLine()
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        Dictionary<string, double> progresses = new Dictionary<string, double>();
        Dictionary<string, int> outDrivers = new Dictionary<string, int>();

        foreach (string driver in drivers)
        {
            progresses[driver] = driver.First();
        }

        for (int i = 0; i < zones.Length; i++)
        {
            double zone = zones[i];

            if (checkpoints.Contains(i))
            {
                foreach (string driver in drivers)
                {
                    if (!progresses.ContainsKey(driver))
                    {
                        continue;
                    }

                    progresses[driver] += zone;

                    if (progresses[driver] <= 0)
                    {
                        progresses.Remove(driver);
                        outDrivers[driver] = i;
                    }
                }
            }
            else
            {
                foreach (string driver in drivers)
                {
                    if (!progresses.ContainsKey(driver))
                    {
                        continue;
                    }

                    progresses[driver] -= zone;

                    if (progresses[driver] <= 0)
                    {
                        progresses.Remove(driver);
                        outDrivers[driver] = i;
                    }
                }
            }
        }

        foreach (string driver in drivers)
        {
            if (progresses.ContainsKey(driver))
            {
                Console.WriteLine($"{driver} - fuel left {progresses[driver]:F2}");
            }
            else
            {
                Console.WriteLine($"{driver} - reached {outDrivers[driver]}");
            }
        }
    }
}
