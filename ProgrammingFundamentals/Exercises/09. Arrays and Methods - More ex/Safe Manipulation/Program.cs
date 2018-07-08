using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split();
        while (true)
        {
            string[] command = Console.ReadLine().Split().ToArray();

            if (command[0] == "END")
            {
                break;
            }
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
                if (int.Parse(command[1]) < 0 || input.Length - 1 < int.Parse(command[1]))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    input[int.Parse(command[1])] = command[2];
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
        Console.WriteLine(string.Join(", ", input));
    }
}
