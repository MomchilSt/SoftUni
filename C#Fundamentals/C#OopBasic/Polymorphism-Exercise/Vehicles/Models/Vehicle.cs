using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicles
    {
        private double fuelConsumption;
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (this.FuelQuantity < neededFuel)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= neededFuel;

            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public void Refuel(double fuel)
        {
            if (this is Truck)
            {
                fuel *= 0.95;
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
