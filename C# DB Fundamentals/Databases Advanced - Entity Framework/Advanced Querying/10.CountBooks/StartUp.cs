using BookShop.Data;
using System;
using System.Linq;

namespace _10.CountBooks
{
    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            using (var db = new BookShopContext())
            {
                Console.WriteLine(CountBooks(db, input));
            }
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int result = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return result;
        }
    }
}
