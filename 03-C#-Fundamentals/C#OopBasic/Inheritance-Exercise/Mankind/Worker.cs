using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(decimal weekSalary, decimal workHoursPerDay, string firstName, string lastName)
            :base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        private decimal WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                workHoursPerDay = value;
            }
        }

        private decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                weekSalary = value;
            }
        }

        private decimal GetSalaryPerHour()
        {
            return (this.WeekSalary / 5) / this.workHoursPerDay;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.AppendLine($"Week Salary: {WeekSalary:f2}");
            builder.AppendLine($"Hours per day: {WorkHoursPerDay:f2}");
            builder.Append($"Salary per hour: {GetSalaryPerHour():f2}");

            return builder.ToString();
        }
    }
}
