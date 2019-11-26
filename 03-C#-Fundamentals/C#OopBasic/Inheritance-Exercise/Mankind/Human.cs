using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                if (char.IsUpper(value[0]) == false)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }

                lastName = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                if (char.IsUpper(value[0]) == false)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                firstName = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"First Name: {FirstName}");
            builder.AppendLine($"Last Name: {LastName}");

            return builder.ToString();
        }
    }
}
