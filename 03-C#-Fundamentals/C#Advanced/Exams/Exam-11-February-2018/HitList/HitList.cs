using System;
using System.Collections.Generic;
using System.Linq;

class HitList
{
    static void Main()
    {
        int targetIndex = int.Parse(Console.ReadLine());
        var keeper = new Dictionary<string, Dictionary<string, string>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end transmissions")
            {
                break;
            }

            string[] tokens = input.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];

            string splitted = tokens[1];

            if (keeper.ContainsKey(name) == false)
            {
                keeper.Add(name, new Dictionary<string, string>());
            }
            else if (keeper.ContainsKey(name))
            {
                if (splitted.Contains(";"))
                {
                    string[] splittedCount = splitted.Split(';');

                    for (int i = 0; i < splittedCount.Length; i++)
                    {
                        string[] currSplit = splittedCount[i].Split(':');
                        if (keeper[name].ContainsKey(currSplit[0]) == false)
                        {
                            keeper[name].Add(currSplit[0], currSplit[1]);
                        }
                        else
                        {
                            keeper[name][currSplit[0]] = currSplit[1];
                        }
                    }
                }
                else
                {
                    string[] currSplit = splitted.Split(':');
                    if (keeper[name].ContainsKey(currSplit[0]) == false)
                    {
                        keeper[name].Add(currSplit[0], currSplit[1]);
                    }
                    else
                    {
                        keeper[name][currSplit[0]] = currSplit[1];
                    }
                }
            }

            if (splitted.Contains(";"))
            {
                string[] splittedCount = splitted.Split(';');

                for (int i = 0; i < splittedCount.Length; i++)
                {
                    string[] currSplit = splittedCount[i].Split(':');
                    if (keeper[name].ContainsKey(currSplit[0]) == false)
                    {
                        keeper[name].Add(currSplit[0], currSplit[1]);
                    }
                    else
                    {
                        keeper[name][currSplit[0]] = currSplit[1];
                    }
                }
            }
            else
            {
                string[] currSplit = splitted.Split(':');
                if (keeper[name].ContainsKey(currSplit[0]) == false)
                {
                    keeper[name].Add(currSplit[0], currSplit[1]);
                }
                else
                {
                    keeper[name][currSplit[0]] = currSplit[1];
                }
            }
        }

        string[] targetInput = Console.ReadLine().Split();
        string target = targetInput[1];

        if (keeper.ContainsKey(target))
        {
            Console.WriteLine($"Info on {target}:");
            int lenghtSum = 0;

            foreach (var keyValues in keeper[target].OrderBy(x => x.Key))
            {
                lenghtSum += keyValues.Key.Length + keyValues.Value.Length;
                Console.WriteLine($"---{keyValues.Key}: {keyValues.Value}");
            }
            Console.WriteLine($"Info index: {lenghtSum}");

            if (targetIndex <= lenghtSum)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {Math.Abs(lenghtSum - targetIndex)} more info.");
            }
        }
    }
}