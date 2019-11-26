using System;

class Program
{
    static void Main()
    {
        double leva = double.Parse(Console.ReadLine());
        double grade = double.Parse(Console.ReadLine());
        double salary = double.Parse(Console.ReadLine());

        double salaryScholarship = 0;
        double gradeScholarship = 0;

        if (leva < salary && grade >= 4.50)
        {
            Math.Floor(salaryScholarship = salary * 0.35);
        }
        if (grade >= 5.50)
        {
            Math.Floor(gradeScholarship = grade * 25);
        }

        if (salaryScholarship > gradeScholarship)
        {
            Console.WriteLine($"You get a Social scholarship {Math.Floor(salaryScholarship):f0} BGN");
        }
        else if (gradeScholarship > salaryScholarship)
        {
            Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(gradeScholarship):f0} BGN");
        }
        else
        {
            Console.WriteLine("You cannot get a scholarship!");
        }
    }
}
