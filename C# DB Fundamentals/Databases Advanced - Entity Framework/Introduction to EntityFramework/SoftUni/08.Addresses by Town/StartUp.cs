using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _08.Addresses_by_Town
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(GetAddressesByTown(dbContext));
            }
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var adresses = context.Addresses
                .Select(a => new {
                    a.AddressText,
                    a.Town.Name,
                    a.Employees.Count
                })
                .OrderByDescending(a => a.Count)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var curr in adresses)
            {
                stringBuilder.AppendLine($"{curr.AddressText}, {curr.Name} - {curr.Count} employees");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
