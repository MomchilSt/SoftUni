using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main()
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car currCar = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(model, currCar);
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                string model = input[1];
                int traveledDistance = int.Parse(input[2]);

                if (cars.ContainsKey(model))
                {
                    cars[model].Drive(traveledDistance);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Value.Model} {(car.Value.FuelAmount):f2} {car.Value.Distance}");
            }
        }
    }
}
