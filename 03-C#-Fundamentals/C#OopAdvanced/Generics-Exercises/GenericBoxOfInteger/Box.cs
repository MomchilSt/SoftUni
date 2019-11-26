using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        private T value;

        public Box(T item)
        {
            this.value = item;
        }

        public override string ToString()
        {
            return $"{this.value.GetType().FullName}: {this.value}";
        }
    }
}
