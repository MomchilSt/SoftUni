using System;

namespace HousePainting01

{

    class HousePainting

    {

        static void Main()

        {

            double houseHight = double.Parse(Console.ReadLine());

            double houseLenght = double.Parse(Console.ReadLine());

            double roofHight = double.Parse(Console.ReadLine());



            double door = 1.2 * 2;

            double window = 1.5 * 1.5;

            double longLows = houseHight * houseLenght * 2;

            double scortLows = houseHight * houseHight * 2;



            double lowsArea = longLows + scortLows - door - 2 * window;

            double roofArea = 2 * ((roofHight * houseHight) / 2) + 2 * (houseHight * houseLenght);



            double lowsPaint = lowsArea / 3.4;

            double roofPaint = roofArea / 4.3;



            Console.WriteLine($"{lowsPaint:0.00}");

            Console.WriteLine($"{roofPaint:0.00}");

        }

    }

}
