using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoster
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;

        private int age;
        private string email;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = "n/a";
            this.age = -1;
        }

        public Employee(string name, decimal salary, string position, string department, string email)
            :this(name, salary, position, department)
        {
            this.Email = email;
        }

        public Employee(string name, decimal salary, string position, string department, int age)
            :this(name, salary, position, department)
        {
            this.Age = age;
        }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
            :this(name, salary, position, department)
        {
            this.Email = email;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public decimal Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public string Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public string Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

    }
}
