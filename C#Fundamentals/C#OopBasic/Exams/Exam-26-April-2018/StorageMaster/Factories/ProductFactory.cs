using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            type = type.ToLower();

            switch (type)
            {
                case "gpu":
                    return new Gpu(price);
                case "harddrive":
                    return new HardDrive(price);
                case "ram":
                    return new Ram(price);
                case "solidstatedrive":
                    return new SolidStateDrive(price);
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }
        }
    }
}
