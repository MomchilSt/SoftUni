using System;

class Program
{
    static void Main()
    {
        int lectures = int.Parse(Console.ReadLine());
        double budget = double.Parse(Console.ReadLine());

        int jelevCounter = 0;
        int royalCounter = 0;
        int roliCounter = 0;
        int trofonCounter = 0;
        int sinoCounter = 0;
        int otherCounter = 0;

        for (int i = 0; i < lectures; i++)
        {
            string teacherName = Console.ReadLine().ToLower();

            if (teacherName == "jelev")
            {
                jelevCounter++;
            }
            else if (teacherName == "royal")
            {
                royalCounter++;
            }
            else if (teacherName == "roli")
            {
                roliCounter++;
            }
            else if (teacherName == "trofon")
            {
                trofonCounter++;
            }
            else if (teacherName == "sino")
            {
                sinoCounter++;
            }
            else
            {
                otherCounter++;
            }
        }

        Console.WriteLine($"Jelev salary: {((budget / lectures) * jelevCounter):f2} lv");
        Console.WriteLine($"RoYaL salary: {((budget / lectures) * royalCounter):f2} lv");
        Console.WriteLine($"Roli salary: {((budget / lectures) * roliCounter):f2} lv");
        Console.WriteLine($"Trofon salary: {((budget / lectures) * trofonCounter):f2} lv");
        Console.WriteLine($"Sino salary: {((budget / lectures) * sinoCounter):f2} lv");
        Console.WriteLine($"Others salary: {((budget / lectures) * otherCounter):f2} lv");
    }
}
