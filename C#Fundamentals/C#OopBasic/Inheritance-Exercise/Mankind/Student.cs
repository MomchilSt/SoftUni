using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string facultyNumber, string firstName, string lastName)
            :base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.AppendLine($"Faculty number: {this.FacultyNumber}");

            return builder.ToString();
        }
    }
}
