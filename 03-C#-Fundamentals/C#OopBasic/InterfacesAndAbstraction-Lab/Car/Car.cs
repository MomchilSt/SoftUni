using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Car
    {
        private string model;
        private string color;

        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Color
        {
            get { return color; }
            protected set { color = value; }
        }


        public string Model
        {
            get { return model; }
            protected set { model = value; }
        }
    }
}
