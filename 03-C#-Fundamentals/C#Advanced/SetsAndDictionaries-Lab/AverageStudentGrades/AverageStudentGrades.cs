using System;
using System.Collections.Generic;
using System.Linq;

class AverageStudentGrades
{
    static void Main()
    {
        Dictionary<string, List<double>> studentGrades = new Dictionary<string, List<double>>();

        int n = int.Parse(Console.ReadLine());


        for (int student = 0; student < n; student++)
        {
            string[] input = Console.ReadLine()
                .Split();

            string name = input[0];
            double grade = double.Parse(input[1]);

            if (studentGrades.ContainsKey(name) == false)
            {
                studentGrades.Add(name, new List<double>());
            }
            else if (studentGrades.ContainsKey(name))
            {
                studentGrades[name].Add(grade);
                continue;
            }

            studentGrades[name].Add(grade);
        }

        foreach (var keyValue in studentGrades)
        {
            Console.Write(keyValue.Key + " -> ");

            for (int i = 0; i < keyValue.Value.Count; i++)
            {
                Console.Write($"{keyValue.Value[i]:f2} ");
            }

            Console.WriteLine($"(avg: {keyValue.Value.Average():f2})");
        }
    }
}