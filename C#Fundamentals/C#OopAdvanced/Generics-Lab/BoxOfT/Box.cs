using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove()
        {
            T element = data.Last();

            this.data.RemoveAt(data.Count - 1);

            return element;
        }
    }
}
