using System;
using System.Collections.Generic;

class ParkingLot
{
    static void Main()
    {
        HashSet<string> parkingLot = new HashSet<string>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            string[] tokens = input.Split(',');

            string direction = tokens[0];
            string carNumber = tokens[1];

            switch (direction)
            {
                case "IN":
                    parkingLot.Add(carNumber);
                    break;

                case "OUT":
                    parkingLot.Remove(carNumber);
                    break;
            }
        }

        if (parkingLot.Count == 0)
        {
            Console.WriteLine("Parking Lot is Empty");
        }
        else
        {
            foreach (var carNum in parkingLot)
            {
                Console.WriteLine(carNum);
            }
        }
    }
}