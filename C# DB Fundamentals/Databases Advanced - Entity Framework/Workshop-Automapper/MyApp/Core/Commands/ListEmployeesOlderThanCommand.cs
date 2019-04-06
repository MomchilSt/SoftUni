using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Core.Commands.Contracts
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ListEmployeesOlderThanCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int age = int.Parse(inputArgs[0]);

            var employees = context.Employees
                .Include(e => e.Manager)
                .Where(e => e.BirthDate != null && e.BirthDate.Value.Year > age)
                .OrderByDescending(e => e.Salary)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                var employeeDto = this.mapper.CreateMappedObject<EmployeeManagerDto>(emp);

                sb.AppendLine($"{employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2} - Manager: {(employeeDto.ManagerLastName == null ? "[no manager]" : employeeDto.ManagerLastName)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
