using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_march_2017_Evening
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double areOfTheHouse = double.Parse(Console.ReadLine());
            int windows = int.Parse(Console.ReadLine());
            double areaOfFoamInPack = double.Parse(Console.ReadLine());
            double priceOfFoamPack = double.Parse(Console.ReadLine());

            double realHouseArea = (areOfTheHouse - (windows * 2.4)) * 1.10;
            double packsNeeded = Math.Ceiling((realHouseArea / areaOfFoamInPack)) * priceOfFoamPack;

            if (budget >= packsNeeded)
            {
                Console.WriteLine($"Spent: {packsNeeded:f2}");
                Console.WriteLine($"Left: {(budget - packsNeeded):f2}");
            }
            else
            {
                Console.WriteLine($"Need more: {(packsNeeded - budget):f2}");
            }
        }
    }
}
