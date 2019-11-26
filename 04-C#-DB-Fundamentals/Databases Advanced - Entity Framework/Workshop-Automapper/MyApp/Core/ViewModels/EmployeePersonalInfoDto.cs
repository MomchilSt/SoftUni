using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.ViewModels
{
    class EmployeePersonalInfoDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime BirthDate { get; set; }

        public string Adress { get; set; }
    }
}
