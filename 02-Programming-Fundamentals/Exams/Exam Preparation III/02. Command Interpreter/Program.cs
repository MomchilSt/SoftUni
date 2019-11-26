using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> list = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        int start = 0;
        int count = 0;

        while (true)
        {
            string[] command = Console.ReadLine().Split(' ');

            if (command[0] == "end")
            {
                break;
            }

            switch (command[0])
            {
                case "reverse":
                    start = int.Parse(command[2]);
                    count = int.Parse(command[4]);

                    if (start < 0 || start >= list.Count ||
                        start + count > list.Count || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }

                    list.Reverse(start, count);
                    break;
                case "sort":
                    start = int.Parse(command[2]);
                    count = int.Parse(command[4]);

                    if (start < 0 || start >= list.Count ||
                        start + count > list.Count || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }

                    list.Sort(start, count, StringComparer.InvariantCulture);
                    break;
                case "rollLeft":
                    count = int.Parse(command[1]) % list.Count;

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        string firstElem = list[0];
                        list.RemoveAt(0);
                        list.Add(firstElem);
                    }
                    break;
                case "rollRight":
                    count = int.Parse(command[1]) % list.Count;

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        string lastElem = list[list.Count - 1];
                        list.RemoveAt(list.Count - 1);
                        list.Insert(0, lastElem);
                    }
                    break;
            }
        }

        Console.WriteLine("[" + string.Join(", ", list) + "]");
    }
}
