using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Foods
{
    public class Mushrooms : Food
    {
        private const int hapiness = -10;

        public Mushrooms()
            :base(hapiness)
        {

        }
    }
}
