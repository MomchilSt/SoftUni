using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
        private const int defaultCapacity = 10;
        private const int defaultGarageSlots = 10;

        public Warehouse(string name)
            : base(name, defaultCapacity, defaultGarageSlots, new List<Vehicle> { new Semi(), new Semi(), new Semi() })
        {
        }
    }
}
