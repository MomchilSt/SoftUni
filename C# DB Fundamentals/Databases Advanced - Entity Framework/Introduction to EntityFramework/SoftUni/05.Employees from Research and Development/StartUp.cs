using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _05.Employees_from_Research_and_Development
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesFromResearchAndDevelopment(dbContext));
            }
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var emplyeees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var emp in emplyeees)
            {
                stringBuilder.AppendLine($"{emp.FirstName} {emp.LastName} from Research and Development - ${emp.Salary:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
