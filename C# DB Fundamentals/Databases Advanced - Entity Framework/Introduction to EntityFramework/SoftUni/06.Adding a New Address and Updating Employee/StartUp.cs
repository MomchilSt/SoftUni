using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace _06.Adding_a_New_Address_and_Updating_Employee
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(AddNewAddressToEmployee(dbContext));
            }
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var adress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(adress);

            var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            nakov.Address = adress;

            context.SaveChanges();

            var employeeAdresses = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Select(a => a.Address.AddressText)
                .Take(10)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var empAdresses in employeeAdresses)
            {
                stringBuilder.AppendLine($"{empAdresses}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
