using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        protected int Capacity { get; set; }
        private List<Item> items;

        public Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public int Load => this.items.Sum(x => x.Weight);

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var item = Items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);

            return item;
        }
    }
}
