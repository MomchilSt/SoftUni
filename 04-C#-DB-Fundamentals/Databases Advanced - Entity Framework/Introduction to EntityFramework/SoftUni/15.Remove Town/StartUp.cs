using SoftUni.Data;
using System;
using System.Linq;

namespace _15.Remove_Town
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new SoftUniContext())
            {
                Console.WriteLine(RemoveTown(dbContext));
            }
        }

        public static string RemoveTown(SoftUniContext context)
        {
            context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList()
                .ForEach(e => e.AddressId = null);

            int adressesCount = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .Count();

            context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList()
                .ForEach(a => context.Addresses.Remove(a));

            context.Towns
                .Remove(context
                .Towns.FirstOrDefault(t => t.Name == "Seattle"));

            return $"{adressesCount} addresses in Seattle were deleted";
        }
    }
}
