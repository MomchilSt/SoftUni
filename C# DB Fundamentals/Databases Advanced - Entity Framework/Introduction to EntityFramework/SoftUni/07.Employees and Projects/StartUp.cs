using SoftUni.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _07.Employees_and_Projects
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesInPeriod(dbContext));
            }
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var emplyees = context.Employees
                .Where(p => p.EmployeesProjects.Any(s => s.Project.StartDate.Year >= 2001 &&
                s.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFullName = x.FirstName + " " + x.LastName,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    }).ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var emp in emplyees)
            {
                stringBuilder.AppendLine($"{emp.EmployeeFullName} - Manager: {emp.ManagerFullName}");

                foreach (var project in emp.Projects)
                {
                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                    var endDate = project.EndDate.HasValue ?
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") 
                        :
                        "not finished";

                    stringBuilder.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
