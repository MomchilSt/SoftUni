using BookShop.Data;
using System;
using System.Linq;
using System.Text;

namespace _13.MostRecentBooks
{
    public class StartUp
    {
        public static void Main()
        {

            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetMostRecentBooks(db));
            }
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks.Select(a => new
                    {
                        a.Book.Title,
                        a.Book.ReleaseDate
                    })
                    .OrderByDescending(e => e.ReleaseDate)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var category in categories)
            {
                stringBuilder.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    stringBuilder.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
