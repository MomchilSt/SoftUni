using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.name = name;
            this.age = age;
            this.Id = id;
        }

        public string Id
        {
            get { return id; }
            private set { id = value; }
        }
    }
}
