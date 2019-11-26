using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        private int battery;

        public Tesla(string model, string color, int battery)
            :base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery
        {
            get { return battery; }
            protected set { battery = value; }
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public virtual string GetCarInfo()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(this.GetCarInfo())
                .AppendLine(this.Start())
                .Append(this.Stop());

            return builder.ToString();
        }
    }
}
