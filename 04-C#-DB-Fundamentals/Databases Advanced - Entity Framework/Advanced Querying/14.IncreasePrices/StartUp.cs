using BookShop.Data;
using System;
using System.Linq;

namespace _14.IncreasePrices
{
    public class StartUp
    {
        public static void Main()
        {

            using (var db = new BookShopContext())
            {
                IncreasePrices(db);
            }
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
    }
}
