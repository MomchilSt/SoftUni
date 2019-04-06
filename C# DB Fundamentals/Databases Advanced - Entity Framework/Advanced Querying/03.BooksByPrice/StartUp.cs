using BookShop.Data;
using System;
using System.Linq;

namespace _03.BooksByPrice
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetBooksByPrice(db));
            }
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(p => p.Price)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));

            return result;
        }
    }
}
