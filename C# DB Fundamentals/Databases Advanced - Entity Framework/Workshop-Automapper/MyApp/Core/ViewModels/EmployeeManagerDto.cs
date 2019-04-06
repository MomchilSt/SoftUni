using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.ViewModels
{
    public class EmployeeManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string ManagerLastName { get; set; }
    }
}
