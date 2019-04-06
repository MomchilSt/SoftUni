using BookShop.Data;
using BookShop.Models.Enums;
using System;
using System.Linq;

namespace _02.GetGoldenBooks
{
    public class StartUp
    {
        public static void Main()
        {

            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetGoldenBooks(db));
            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }
    }
}
