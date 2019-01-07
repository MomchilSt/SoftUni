using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Car
    {
        private string model;
        private int carSpeed;

        public Car(string model, int carSpeed)
        {
            this.Model = model;
            this.CarSpeed = carSpeed;
        }

        public int CarSpeed
        {
            get { return carSpeed; }
            set { carSpeed = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public override string ToString()
        {
            return this.Model + " " + this.CarSpeed;
        }
    }
}
