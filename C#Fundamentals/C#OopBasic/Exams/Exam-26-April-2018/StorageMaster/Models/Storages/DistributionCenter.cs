using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public class DistributionCenter : Storage
    {
        private const int defaultCapacity = 2;
        private const int defaultGarageSlots = 5;

        public DistributionCenter(string name)
            : base(name, defaultCapacity, defaultGarageSlots, new List<Vehicle> { new Van(), new Van(), new Van() })
        {
        }
    }
}
