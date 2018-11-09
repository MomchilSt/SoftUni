using System;
using System.Linq;

class JaggedArrayModification
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[][] matrix = new int[n][];

        for (int row = 0; row < n; row++)
        {
            matrix[row] = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            string[] tokens = input.Split();

            string command = tokens[0];
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);

            if (row < 0 || row > n - 1 || col < 0 || col > n - 1)
            {
                Console.WriteLine("Invalid coordinates");
                continue;
            }

            switch (command)
            {
                case "Add":
                    matrix[row][col] = matrix[row][col] + value;
                    break;

                case "Subtract":
                    matrix[row][col] = matrix[row][col] - value;
                    break;
            }
        }

        foreach (int[] line in matrix)
        {
            Console.WriteLine(string.Join(" ", line));
        }
    }
}
