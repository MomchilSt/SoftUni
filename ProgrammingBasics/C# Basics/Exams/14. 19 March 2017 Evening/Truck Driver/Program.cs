using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Driver
{
    class Program
    {
        static void Main(string[] args)
        {

            var sezon = Console.ReadLine();
            var kilometri = double.Parse(Console.ReadLine());

            var price = 0.0;

            if (kilometri <= 5000 && sezon == "Spring" || sezon == "Autumn") { price = 0.75; }
            else if (kilometri > 5000 && kilometri <= 10000 && sezon == "Spring" || sezon == "Autumn") { price = 0.95; }

            else if (kilometri <= 5000 && sezon == "Summer") { price = 0.90; }
            else if (kilometri > 5000 && kilometri <= 10000 && sezon == "Summer") { price = 1.10; }
            else if (kilometri <= 5000 && sezon == "Winter") { price = 1.05; }
            else if (kilometri > 5000 && kilometri <= 10000 && sezon == "Winter") { price = 1.25; }

            else if (kilometri > 10000 && kilometri <= 20000 && sezon == "Spring" || sezon == "Autumn" || sezon == "Summer" || sezon == "Winter") { price = 1.45; }

            var sum = kilometri * price * 4;
            var salary = sum - (sum * 0.10);

            Console.WriteLine($"{salary:f2}");
        }
    }
}

