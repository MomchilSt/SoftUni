using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> plans = Console.ReadLine()
            .Split(',')
            .ToList();

        plans = plans.Select(x => x.TrimStart()).ToList();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "course start")
            {
                break;
            }

            string[] tokens = input.Split(':');
            string command = tokens[0];

            if (command == "Add")
            {
                string lesson = tokens[1];
                plans.Add(lesson);
            }
            else if (command == "Insert")
            {
                string lesson = tokens[1];
                int index = int.Parse(tokens[2]);

                plans.Insert(index, lesson);
            }
            else if (command == "Remove")
            {
                string lesson = tokens[1].Trim();
                plans.Remove(lesson);
            }
            else if (command == "Swap")
            {
                string firstLesson = tokens[1];
                string secondLesson = tokens[2];

                if (plans.Contains(firstLesson) && plans.Contains(secondLesson))
                {
                    int indexOfFirst = plans.IndexOf(firstLesson);
                    int indexOfSecond = plans.IndexOf(secondLesson);

                    string temp = plans[indexOfFirst];
                    plans[indexOfFirst] = plans[indexOfSecond];
                    plans[indexOfSecond] = temp;

                    if (plans.Contains(plans[indexOfSecond]+"-Exercise"))
                    {
                        temp = plans[indexOfSecond] + "-Exercise";
                        plans.Remove(plans[indexOfSecond] + "-Exercise");
                        plans.Insert(indexOfSecond + 1, temp);
                    }
                    if (plans.Contains(plans[indexOfFirst] + "-Exercise"))
                    {
                        temp = plans[indexOfFirst] + "-Exercise";
                        plans.Remove(plans[indexOfFirst] + "-Exercise");
                        plans.Insert(indexOfFirst + 1, temp);
                    }
                }
            }
            else if (command == "Exercise")
            {
                string lesson = tokens[1];

                if (plans.Contains(lesson) && plans.Contains(lesson+"-Exercise"))
                {
                    continue;
                }
                if (plans.Contains(lesson))
                {
                    string exercise = lesson + "-Exercise";
                    int lessonIndex = plans.IndexOf(lesson);

                    plans.Insert(lessonIndex + 1, exercise);
                }
                else
                {
                    string exercise = lesson + "-Exercise";
                    plans.Add(lesson);
                    plans.Add(exercise);
                }
            }
        }

        for (int i = 0; i < plans.Count; i++)
        {
            string print = plans[i];
            Console.WriteLine($"{i+1}.{print.Trim()}");
        }
    }
}