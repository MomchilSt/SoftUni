using BookShop.Data;
using System;
using System.Linq;

namespace _11.TotalBookCopies
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                Console.WriteLine(CountCopiesByAuthor(db));
            }
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copiesByAuthor = context.Authors
                .Select(x => new
                {
                    Name = $"{x.FirstName} {x.LastName}",
                    Copies = x.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(a => a.Copies)
                .ToList();

            var result = string.Join(Environment.NewLine, copiesByAuthor.Select(a => $"{a.Name} - {a.Copies}"));

            return result;
        }
    }
}
