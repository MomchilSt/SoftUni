using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _04._Employees_with_Salary_Over_50_000
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesWithSalaryOver50000(dbContext));
            }
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var emplyees = context.Employees
                .Select(e => new { e.FirstName, e.Salary })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var emp in emplyees)
            {
                stringBuilder.AppendLine($"{emp.FirstName} - {emp.Salary:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
