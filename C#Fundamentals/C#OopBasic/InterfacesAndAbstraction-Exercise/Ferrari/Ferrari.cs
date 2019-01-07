using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IDriveable
    {
        private string model;
        private string driver;

        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }

        public string Driver
        {
            get { return driver; }
            private set { driver = value; }
        }

        public string Model
        {
            get { return model; }
            private set { model = value; }
        }

        public string Breaks()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{Breaks()}/{Gas()}/{this.Driver}";
        }
    }
}
