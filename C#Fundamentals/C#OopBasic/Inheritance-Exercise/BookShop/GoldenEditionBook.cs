﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price)
            : base(title, author, price)
        {
        }

        protected override decimal Price
        {
            get
            {
                return base.Price * 1.3m;
            }
        }
    }
}
