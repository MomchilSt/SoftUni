using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private int capacity;
        private List<Product> trunk;

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public bool IsFull => Trunk.Sum(x => x.Weight) >= Capacity;

        public bool IsEmpty => Trunk.Count == 0;

        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product product = trunk.Last();
            return product;
        }
    }
}
