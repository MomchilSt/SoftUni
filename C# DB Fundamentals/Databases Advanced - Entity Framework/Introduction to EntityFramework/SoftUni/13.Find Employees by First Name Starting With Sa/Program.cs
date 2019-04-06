using System;

namespace _13.Find_Employees_by_First_Name_Starting_With_Sa
{
    public class Program
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(dbContext));
            }
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(f => f.FirstName)
                .ThenBy(l => l.LastName)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
