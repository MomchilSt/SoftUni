using System;
using System.Collections.Generic;
using System.Linq;

class HospitalV2
{
    static void Main()
    {
        var departments = new Dictionary<string, List<string>>();
        var doctors = new Dictionary<string, List<string>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Output")
            {
                break;
            }

            var patientData = input.Split();

            var department = patientData[0];
            var doctor = patientData[1] + " " + patientData[2];
            var patient = patientData[3];

            if (doctors.ContainsKey(doctor) == false)
            {
                doctors.Add(doctor, new List<string>());
            }
            doctors[doctor].Add(patient);

            if (departments.ContainsKey(department) == false)
            {
                departments.Add(department, new List<string>());
            }
            departments[department].Add(patient);
        }

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            var tokens = input.Split();

            if (tokens.Length == 1)
            {
                foreach (var patiet in departments[input])
                {
                    Console.WriteLine(patiet);
                }
            }
            else
            {
                int roomNumber = 0;
                if (int.TryParse(tokens[1], out roomNumber))
                {
                    var skip = 3 * (roomNumber - 1);

                    foreach (var patient in departments[tokens[0]].Skip(skip).Take(3).OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    foreach (var patient in doctors[input].OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }
    }
}