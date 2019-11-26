using BookShop.Data;
using System;
using System.Linq;

namespace _04.GetBooksNotReleasedIn
{
    public class StartUp
    {
        public static void Main()
        {
            var year = int.Parse(Console.ReadLine());

            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetBooksNotReleasedIn(db, year));
            }
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }
    }
}
