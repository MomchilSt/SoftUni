using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using System;


namespace MyApp.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private readonly MyAppContext context;

        public SetBirthdayCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            int id = int.Parse(inputArgs[0]);
            DateTime date = DateTime.ParseExact(inputArgs[1], "dd-MM-yyyy", null);

            var employee = this.context.Employees.Find(id);

            if (employee == null)
            {
                return $"Employee with id is not found!";
            }

            employee.BirthDate = date;
            this.context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}'s birth date is set to {inputArgs[1]}";
        }
    }
}
