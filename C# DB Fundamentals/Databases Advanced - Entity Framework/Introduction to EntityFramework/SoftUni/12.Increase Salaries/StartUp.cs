using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _12.Increase_Salaries
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(IncreaseSalaries(dbContext));
            }
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            context.Employees
                .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                        .Contains(e.Department.Name))
                    .ToList()
                    .ForEach(e => e.Salary *= 1.12m);

            context.SaveChanges();

            var employees = context.Employees
                .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                        .Contains(e.Department.Name))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new {
                        e.FirstName,
                        e.LastName,
                        e.Salary
                    })
                    .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
