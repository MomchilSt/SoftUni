using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _10.Departments_with_More_Than_5_Employees
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(GetDepartmentsWithMoreThan5Employees(dbContext));
            }
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(e => e.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(x => new {
                    DepartmentName = x.Name,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Emplyees = x.Employees.Select(e => new {
                        EmployeeFullName = e.FirstName + " " + e.LastName,
                        JobTitle = e.JobTitle
                    })
                    .OrderBy(f => f.EmployeeFullName)
                    .ToList()
                });

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var dep in departments)
            {
                stringBuilder.AppendLine($"{dep.DepartmentName} - {dep.ManagerFullName}");

                foreach (var emp in dep.Emplyees)
                {
                    stringBuilder.AppendLine($"{emp.EmployeeFullName} - {emp.JobTitle}");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
