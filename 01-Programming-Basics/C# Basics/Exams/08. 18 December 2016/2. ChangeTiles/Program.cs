using System;

namespace _2.ChangeTiles
{
    class Program
    {
        static void Main()
        {
            double money = double.Parse(Console.ReadLine());
            double floorW = double.Parse(Console.ReadLine());
            double floorH = double.Parse(Console.ReadLine());
            double taleW = double.Parse(Console.ReadLine());
            double taleH = double.Parse(Console.ReadLine());
            double tilePrice = double.Parse(Console.ReadLine());
            double payMaster = double.Parse(Console.ReadLine());

            double floorArea =  floorW * floorH;
            double taleArea = taleW * taleH / 2;
            double allTales = Math.Ceiling(floorArea / taleArea) + 5;
            double cost = allTales * tilePrice + payMaster;
            double diff = Math.Abs(money - cost);

            if (cost <= money)
            {
                Console.WriteLine($"{diff:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"You'll need {diff:f2} lv more.");
            }
        }
    }
}
