using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _11.Find_Latest_10_Projects
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(GetLatestProjects(dbContext));
            }
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p => p.Name)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var project in projects)
            {
                var date = project.StartDate.ToString("M'/'d'/'yyyy h:mm:ss tt");

                stringBuilder.AppendLine(project.Name);
                stringBuilder.AppendLine(project.Description);
                stringBuilder.AppendLine(date);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
