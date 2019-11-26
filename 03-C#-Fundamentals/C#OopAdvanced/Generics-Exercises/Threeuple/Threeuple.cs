using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<T1, T2, T3>
    {

        private T1 item1;
        private T2 item2;
        private T3 item3;

        public Threeuple(T1 first, T2 second, T3 third)
        {
            this.item1 = first;
            this.item2 = second;
            this.item3 = third;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}