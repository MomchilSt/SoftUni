using System;

namespace Ferrari
{
    public class StartUp
    {
        static void Main()
        {
            string driver = Console.ReadLine();
            var ferrari = new Ferrari(driver);
            Console.WriteLine(ferrari);
        }
    }
}
