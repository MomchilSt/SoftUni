using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _14.Delete_Project_by_Id
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(DeleteProjectById(dbContext));
            }
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects
                .FirstOrDefault(x => x.ProjectId == 2);

            var employeesProjects = context.EmployeesProjects
                .Where(x => x.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(employeesProjects);
            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Select(x => x.Name)
                .Take(10)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var currProject in projects)
            {
                stringBuilder.AppendLine(currProject);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
