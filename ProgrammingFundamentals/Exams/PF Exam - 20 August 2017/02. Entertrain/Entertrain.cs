using System;
using System.Collections.Generic;
using System.Linq;

class Entertrain
{
    static void Main()
    {
        int power = int.Parse(Console.ReadLine());

        List<int> sequence = new List<int>();

        int elementsSum = 0;
        int avr = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "All ofboard!") { break; }
            int weight = int.Parse(input);

            sequence.Add(weight);

            if (sequence.Sum() > power)
            {
                elementsSum = sequence.Sum();
                avr = elementsSum / sequence.Count;

                int minDistance = int.MaxValue;
                int minIndex = -1;
                for (int i = 0; i < sequence.Count; i++)
                {
                    int distance = Math.Abs(sequence[i] - avr);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        minIndex = i;
                    }
                }

                sequence.RemoveAt(minIndex);
            }
        }

        sequence.Reverse();
        sequence.Add(power);

        Console.WriteLine(string.Join(" ", sequence));
    }
}
