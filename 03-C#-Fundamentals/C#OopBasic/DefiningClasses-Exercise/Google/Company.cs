using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Company
    {
        private string companyName;
        private string department;
        private decimal salary;

        public Company(string companyName, string department, decimal salary)
        {
            this.CompanyName = companyName;
            this.Department = department;
            this.Salary = salary;
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2:f2}", this.companyName, this.Department, this.Salary);
        }
    }
}
