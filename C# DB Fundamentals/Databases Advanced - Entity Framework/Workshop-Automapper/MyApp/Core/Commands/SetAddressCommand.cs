using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Core.Commands
{
    public class SetAddressCommand : ICommand
    {
        private readonly MyAppContext context;

        public SetAddressCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            int id = int.Parse(inputArgs[0]);
            string address = string.Join(" ", inputArgs.Skip(1));

            var employee = this.context.Employees.Find(id);

            if (employee == null)
            {
                return $"Employee with id is not found!";
            }

            employee.Address = address;
            this.context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}'s address is set to {string.Join(" ", inputArgs.Skip(1))}";
        }
    }
}
