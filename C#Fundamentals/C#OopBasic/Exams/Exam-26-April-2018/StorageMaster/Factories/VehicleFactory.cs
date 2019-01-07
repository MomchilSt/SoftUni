using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "semi":
                    return new Semi();
                case "truck":
                    return new Truck();
                case "van":
                    return new Van();
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }
        }
    }
}
