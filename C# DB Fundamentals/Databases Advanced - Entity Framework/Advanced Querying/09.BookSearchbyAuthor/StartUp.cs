using BookShop.Data;
using System;
using System.Linq;

namespace _09.BookSearchbyAuthor
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetBooksByAuthor(db, input));
            }
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(x => new
                {
                    x.Title,
                    x.Author.FirstName,
                    x.Author.LastName
                })
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.FirstName} {x.LastName})"));

            return result;
        }
    }
}
