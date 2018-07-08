using System;

namespace ZelenchukovaBorsa
{
    class Program
    {
        static void Main()
        {
            double priceM = double.Parse(Console.ReadLine());
            double priceN = double.Parse(Console.ReadLine());
            ushort kgM = ushort.Parse(Console.ReadLine());
            ushort kgN = ushort.Parse(Console.ReadLine());

            var income = priceN * kgN + priceM * kgM;
            Console.WriteLine(income / 1.94);
        }
    }
}
