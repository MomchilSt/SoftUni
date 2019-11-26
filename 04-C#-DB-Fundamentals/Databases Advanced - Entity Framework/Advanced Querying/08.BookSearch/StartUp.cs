using BookShop.Data;
using System;
using System.Linq;

namespace _08.BookSearch
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetBookTitlesContaining(db, input));
            }
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }
    }
}
