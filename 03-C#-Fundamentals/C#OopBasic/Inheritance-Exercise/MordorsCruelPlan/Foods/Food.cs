using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Foods
{
    public abstract class Food
    {
        public Food(int hapiness)
        {
            this.Happiness = hapiness;
        }

        public int Happiness { get; private set; }
    }
}
