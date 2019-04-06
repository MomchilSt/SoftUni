using System;
using System.Linq;
using System.Text;
using SoftUni.Data;

namespace _03.Employees_Full_Information
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesFullInformation(dbContext));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var employees = context.Employees
                .Select(e => new { e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary, e.EmployeeId })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var emp in employees)
            {
                stringBuilder.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
