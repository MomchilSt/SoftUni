using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Employee[] employees = new Employee[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal amount = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                if (input.Length == 4)
                {
                    employees[i] = new Employee(name, amount, position, department);
                }
                else if (input.Length == 5)
                {
                    int age;
                    bool isAge = int.TryParse(input[4], out age);

                    if (isAge)
                    {
                        employees[i] = new Employee(name, amount, position, department, age);
                    }
                    else
                    {
                        string email = input[4];
                        employees[i] = new Employee(name, amount, position, department, email);
                    }
                }
                else
                {
                    string email = input[4];
                    int age = int.Parse(input[5]);
                    employees[i] = new Employee(name, amount, position, department, email, age);
                }
            }

            Dictionary<string, decimal> totalSalary = new Dictionary<string, decimal>();
            foreach (Employee employee in employees)
            {
                if (totalSalary.ContainsKey(employee.Department))
                {
                    totalSalary[employee.Department] += employee.Salary;
                }
                else
                {
                    totalSalary[employee.Department] = employee.Salary;
                }
            }

            decimal averageSalary = decimal.MinValue;
            string highestDepartment = string.Empty;

            foreach (var curr in totalSalary.Keys)
            {
                decimal currAverage = totalSalary[curr] / employees.Where(e => e.Department == curr).Count();
                if (currAverage > averageSalary)
                {
                    averageSalary = currAverage;
                    highestDepartment = curr;
                }
            }

            Console.WriteLine($"Highest Average Salary: {highestDepartment}");
            foreach (var dep in employees.Where(e => e.Department == highestDepartment).OrderByDescending(e => e.Salary))
            {
                Console.WriteLine("{0} {1:f2} {2} {3}", dep.Name, dep.Salary, dep.Email, dep.Age);
            }
        }
    }
}
