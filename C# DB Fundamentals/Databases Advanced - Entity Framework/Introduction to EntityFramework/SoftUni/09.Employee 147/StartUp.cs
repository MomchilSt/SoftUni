using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _09.Employee_147
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(GetEmployee147(dbContext));
            }
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    a.JobTitle,
                    Projects = a.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name
                    })
                    .OrderBy(p => p.Name)
                    .ToList()
                })
                .First();

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var town in employee.Projects)
            {
                stringBuilder.AppendLine(town.Name);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
