using System;
using System.Collections.Generic;

class TrafficLight
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var queue = new Queue<string>();
        int greenCounter = 0;

        while (true)
        {
            string command = Console.ReadLine();
            
            if (command == "end")
            {
                break;
            }
            else if (command == "green")
            {
                greenCounter++;
            }
            else
            {
                queue.Enqueue(command);
            }
        }

        greenCounter *= n;
        int counter = 0;

        for (int i = 0; i < greenCounter; i++)
        {
            if (queue.Count != 0)
            {
                Console.WriteLine($"{queue.Dequeue()} paased!");
                counter++;
            }
        }

        Console.WriteLine($"{counter} cars passed the crossroads.");
    }
}