using BookShop.Data;
using System;
using System.Linq;

namespace _07.GetAuthorNamesEndingIn
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetAuthorNamesEndingIn(db, input));
            }
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Books
                .Where(b => b.Author.FirstName.EndsWith(input))
                .Select(a => $"{a.Author.FirstName} {a.Author.LastName}")
                .OrderBy(a => a)
                .Distinct()
                .ToList();

            var result = string.Join(Environment.NewLine, authors);

            return result;
        }
    }
}
