﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double airConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += airConditionConsumption;
        }
    }
}
