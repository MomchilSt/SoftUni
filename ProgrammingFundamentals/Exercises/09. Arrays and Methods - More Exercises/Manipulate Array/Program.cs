using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine().Split().ToArray();

            if (command[0] == "Distinct")
            {
                input = input.Distinct().ToArray();
            }
            else if (command[0] == "Reverse")
            {
                input = input.Reverse().ToArray();
            }
            else if (command[0] == "Replace")
            {
                input[int.Parse(command[1])] = command[2];
            }
        }

        Console.WriteLine(string.Join(", ", input));
    }
}
