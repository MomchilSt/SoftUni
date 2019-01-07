using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double distance;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.distance = 0;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value;  }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public double Distance
        {
            get { return this.distance; }
        }

        public void Drive(double distance)
        {
            if (this.fuelAmount < distance * this.fuelConsumption)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.fuelAmount -= distance * this.fuelConsumption;
                this.distance += distance;
            }
        }
    }
}
