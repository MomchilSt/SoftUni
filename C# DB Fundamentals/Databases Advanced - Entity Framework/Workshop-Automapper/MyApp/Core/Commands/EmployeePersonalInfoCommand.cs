using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int id = int.Parse(inputArgs[0]);

            var employee = this.context.Employees.Find(id);

            if (employee == null)
            {
                return $"Employee with id is not found!";
            }

            var employeeDto = this.mapper.CreateMappedObject<EmployeePersonalInfoDto>(employee);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}");
            sb.AppendLine($"Birthday: {employeeDto.BirthDate}");
            sb.AppendLine($"Adress: {employeeDto.Adress}");

            return sb.ToString().TrimEnd();
        }
    }
}
