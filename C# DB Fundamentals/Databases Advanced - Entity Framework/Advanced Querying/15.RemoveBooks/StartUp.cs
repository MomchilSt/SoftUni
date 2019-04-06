using BookShop.Data;
using System;
using System.Linq;

namespace _15.RemoveBooks
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                Console.WriteLine(RemoveBooks(db));
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return books.Count;
        }
    }
}
