using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Parents
    {
        private string parentName;
        private string parentBirthday;

        public Parents(string parentName, string parentBirthday)
        {
            this.ParentName = parentName;
            this.ParentBirthday = parentBirthday;
        }

        public string ParentBirthday
        {
            get { return parentBirthday; }
            set { parentBirthday = value; }
        }

        public string ParentName
        {
            get { return parentName; }
            set { parentName = value; }
        }

        public override string ToString()
        {
            return this.ParentName + " " + this.ParentBirthday;
        }
    }
}
