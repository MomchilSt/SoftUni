using System;
using System.Linq;

class Ladybugs
{
    static void Main()
    {
        int fieldLength = int.Parse(Console.ReadLine());
        int[] intialIndexes = Console.ReadLine()
            .Split(' ')
            .Select(x => int.Parse(x))
            .Where(x => x >= 0 && x < fieldLength)
            .ToArray();

        int[] field = new int[fieldLength];

        foreach (int index in intialIndexes)
        {
            field[index] = 1;
        }

        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');

            if (input[0] == "end")
            {
                break;
            }

            int index = int.Parse(input[0]);
            string direction = input[1];
            int flyLength = int.Parse(input[2]);

            if (index < 0 || index >= field.Length)
            {
                continue;
            }

            if (field[index] == 0)
            {
                continue;
            }

            if (flyLength < 0)
            {
                flyLength = Math.Abs(flyLength);

                if (direction == "right")
                {
                    direction = "left";
                }
                else
                {
                    direction = "right";
                }
            }

            field[index] = 0;
            int moveAt = index;
            while (true)
            {
                if (direction == "right")
                {
                    moveAt += flyLength;
                    if (moveAt < 0 || moveAt >= field.Length)
                    {
                        break;
                    }
                    if (field[moveAt] == 0)
                    {
                        field[moveAt] = 1;
                        break;
                    }
                }
                else
                {
                    moveAt -= flyLength;
                    if (moveAt < 0 || moveAt >= field.Length)
                    {
                        break;
                    }
                    if (field[moveAt] == 0)
                    {
                        field[moveAt] = 1;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(string.Join(" ", field));
    }
}
