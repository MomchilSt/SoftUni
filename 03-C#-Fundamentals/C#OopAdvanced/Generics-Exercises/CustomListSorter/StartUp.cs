using System;

namespace CustomListSorter
{
    public class StartUp
    {
        public static void Main()
        {
            ISoftUniList<string> softUniList = new SoftUniList<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split();
                string command = inputArgs[0];

                switch (command)
                {
                    case "Add":
                        softUniList.Add(inputArgs[1]);
                        break;
                    case "Remove":
                        softUniList.Remove(int.Parse(inputArgs[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(softUniList.Contains(inputArgs[1]));
                        break;
                    case "Swap":
                        softUniList.Swap(int.Parse(inputArgs[1]), int.Parse(inputArgs[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(softUniList.CountGreaterThan(inputArgs[1]));
                        break;
                    case "Max":
                        Console.WriteLine(softUniList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(softUniList.Min());
                        break;
                    case "Print":
                        Console.WriteLine(softUniList);
                        break;
                    case "Sort":
                        softUniList.Sorter();
                        break;
                    default:
                        throw new ArgumentException();
                }

                input = Console.ReadLine();
            }
        }
    }
}
