using System;

namespace Mankind
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                string[] firstInput = Console.ReadLine().Split();
                string[] secondInput = Console.ReadLine().Split();

                string facultyNumber = firstInput[2];

                Student student = new Student(facultyNumber, firstInput[0], firstInput[1]);

                decimal weeklySalary = decimal.Parse(secondInput[2]);
                decimal workHours = decimal.Parse(secondInput[3]);

                Worker worker = new Worker(weeklySalary, workHours, secondInput[0], secondInput[1]);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
