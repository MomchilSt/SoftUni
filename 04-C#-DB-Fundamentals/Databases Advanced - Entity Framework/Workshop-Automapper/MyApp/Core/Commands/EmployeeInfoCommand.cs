using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeeInfoCommand(MyAppContext context, Mapper mapper)
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

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            return $"{employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} -  ${employeeDto.Salary:f2}";
        }
    }
}
