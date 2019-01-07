﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Contracts
{
    public interface IVehicles
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        void Drive(double distance);

        void Refuel(double fuel);
    }
}
