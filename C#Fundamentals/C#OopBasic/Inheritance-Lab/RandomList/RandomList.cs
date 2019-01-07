using System;
using System.Collections.Generic;
using System.Text;

namespace RandomList
{
    public class RandomList
    {
        private Random rdn;

        public RandomList()
        {
            this.rdn = new Random();
        }

        public int RandomInteger()
        {
            return this.rdn.Next();
        }

        public int RandomString() => this.RandomInteger();
    }
}
