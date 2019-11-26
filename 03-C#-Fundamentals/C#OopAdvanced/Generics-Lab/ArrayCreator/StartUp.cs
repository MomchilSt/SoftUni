using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main()
        {
            string[] strings = ArrayCreator.Create(5, "pesho");
            int[] integers = ArrayCreator.Create(10, 33);
        }
    }
}
