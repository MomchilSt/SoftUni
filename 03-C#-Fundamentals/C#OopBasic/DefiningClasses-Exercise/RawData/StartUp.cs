using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string model = inputArgs[0];
                int engineSpeed = int.Parse(inputArgs[1]);
                int enginePower = int.Parse(inputArgs[2]);
                int cargoWeight = int.Parse(inputArgs[3]);
                string cargoType = inputArgs[4];

                List<Tire> tires = new List<Tire>();

                for (int j = 0; j < 4; j+=2)
                {
                    double tirePressure = double.Parse(inputArgs[5 + j]);
                    int tireAge = int.Parse(inputArgs[6 + j]);

                    Tire tire = new Tire(tirePressure, tireAge);
                    tires.Add(tire);
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<Car> resultCars = new List<Car>();

            if (command == "fragile")
            {
                resultCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(s => s.Pressure < 1)).ToList();
            }
            else
            {
                resultCars = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
            }

            foreach (var car in resultCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
