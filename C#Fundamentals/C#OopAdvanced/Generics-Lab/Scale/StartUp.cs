using System;

namespace GenericScale
{
    public class GenericScale
    {
        public static void Main()
        {
            var scale1 = new Scale<int>(5, 10);
            Console.WriteLine(scale1.GetHeavier());

            var scale2 = new Scale<string>("Man", "Woman");
            Console.WriteLine(scale2.GetHeavier());
        }
    }
}
