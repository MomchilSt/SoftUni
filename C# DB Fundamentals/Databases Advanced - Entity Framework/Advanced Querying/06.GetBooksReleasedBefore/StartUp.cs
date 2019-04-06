using BookShop.Data;
using System;
using System.Linq;

namespace _06.GetBooksReleasedBefore
{
    public class StartUp
    {
        public static void Main()
        {
            string date = Console.ReadLine();

            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetBooksReleasedBefore(db, date));
            }
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate < releaseDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.Price,
                    x.EditionType
                })
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));

            return result;
        }
    }
}
