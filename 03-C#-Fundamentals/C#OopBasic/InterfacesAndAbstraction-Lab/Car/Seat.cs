using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : Car, ICar
    {
        public Seat(string model, string color)
            :base(model, color)
        {

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
