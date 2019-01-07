﻿using StorageMaster.Models.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            type = type.ToLower();

            switch (type)
            {
                case "automatedwarehouse":
                    return new AutomatedWarehouse(name);
                case "distributioncenter":
                    return new DistributionCenter(name);
                case "warehouse":
                    return new Warehouse(name);
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }
        }
    }
}
