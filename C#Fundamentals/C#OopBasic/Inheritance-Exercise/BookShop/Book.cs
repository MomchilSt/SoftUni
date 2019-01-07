using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        protected virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        protected string Author
        {
            get { return author; }
            set
            {
                string[] names = value.Split();

                if (names.Length == 1)
                {
                    if (char.IsDigit(names[0][0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }
                else if (names.Length == 2)
                {
                    if (char.IsDigit(names[0][0]) || char.IsDigit(names[1][0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }

                this.author = value;
            }
        }

        protected string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type: ").Append(this.GetType().Name);
            sb.Append(Environment.NewLine);
            sb.Append("Title: ").Append(this.Title);
            sb.Append(Environment.NewLine);
            sb.Append("Author: ").Append(this.Author);
            sb.Append(Environment.NewLine);
            sb.Append(String.Format("Price: {0:F2}", this.Price));
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }   
    }
}
