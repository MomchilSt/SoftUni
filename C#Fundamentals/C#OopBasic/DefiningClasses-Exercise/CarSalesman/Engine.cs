using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private string power;
        private int displacement;
        private string efficiency;

        public Engine(string model, string power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = 0;
            this.Efficiency = "n/a";
        }

        public Engine(string model, string power, int displacement)
            :this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, string power, string efficiency)
            :this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, string power, int displacement, string efficiency)
            :this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public string Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

    }
}
