using BookShop.Data;
using System;
using System.Linq;

namespace _12.ProfitbyCategory
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetTotalProfitByCategory(db));
            }
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Select(cb => cb.Book.Copies * cb.Book.Price).Sum()
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            var result = string.Join(Environment.NewLine, categories.Select(c => $"{c.Name} ${c.Profit:f2}"));

            return result;
        }
    }
}
