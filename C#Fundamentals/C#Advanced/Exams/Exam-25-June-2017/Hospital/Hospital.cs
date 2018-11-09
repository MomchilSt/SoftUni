using System;
using System.Collections.Generic;
using System.Linq;

class Hospital
{
    static void Main()
    {
        var doctorsAndPatients = new Dictionary<string, List<string>>();
        var departmentsAndRooms = new Dictionary<string, Dictionary<int, List<string>>>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Output")
            {
                break;
            }

            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string department = tokens[0];
            string doctor = tokens[1] + " " + tokens[2];
            string patient = tokens[3];

            FillDoctorsPatients(doctorsAndPatients, doctor, patient);
            FillDepartments(departmentsAndRooms, department, patient);
        }

        while (true)
        {
            string[] searchFor = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (searchFor[0] == "End")
            {
                break;   
            }

            if (departmentsAndRooms.ContainsKey(searchFor[0]))
            {
                if (searchFor.Length == 1)
                {
                    foreach (var dep in departmentsAndRooms[searchFor[0]])
                    {
                        foreach (var item in dep.Value)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                else
                {
                    int room = int.Parse(searchFor[1]);

                    foreach (var item in departmentsAndRooms[searchFor[0]])
                    {
                        if (item.Key == room)
                        {
                            foreach (var patient in item.Value.OrderBy(x => x))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var doc in doctorsAndPatients)
                {
                    string fullName = string.Join(" ", searchFor).TrimEnd();

                    if (doc.Key == fullName)
                    {
                        foreach (var patient in doc.Value.OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
            }
        }
    }

    private static void FillDepartments(Dictionary<string, Dictionary<int, List<string>>> departmentsAndRooms, string department, string patient)
    {
        if (departmentsAndRooms.ContainsKey(department) == false)
        {
            departmentsAndRooms.Add(department, new Dictionary<int, List<string>>());

            for (int i = 1; i <= 20; i++)
            {
                departmentsAndRooms[department].Add(i, new List<string>(3));
            }
        }

        for (int i = 1; i <= 20; i++)
        {
            if (departmentsAndRooms[department][i].Count < 3)
            {
                departmentsAndRooms[department][i].Add(patient);
                break;
            }
            continue;
        }
        
    }

    private static void FillDoctorsPatients(Dictionary<string, List<string>> doctorsAndPatients, string doctor, string patient)
    {
        if (doctorsAndPatients.ContainsKey(doctor) == false)
        {
            doctorsAndPatients.Add(doctor, new List<string>());
        }

        doctorsAndPatients[doctor].Add(patient);
    }
}