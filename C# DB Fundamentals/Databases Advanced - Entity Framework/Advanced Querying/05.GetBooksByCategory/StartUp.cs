using BookShop.Data;
using System;
using System.Linq;

namespace _05.GetBooksByCategory
{
    public class StartUp
    {
        public static void Main()
        {
            var category = Console.ReadLine();

            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetBooksByCategory(db, category));
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(bc => bc.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }
    }
}
