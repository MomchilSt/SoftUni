using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_CarsSalesman
{
    public class CarSalesman
    {
        public static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                int power = int.Parse(tokens[1]);

                if (tokens.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (tokens.Length == 3)
                {
                    int displacement;
                    bool isDisplacement = int.TryParse(tokens[2], out displacement);
                    if (isDisplacement)
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = tokens[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }
                }
                else if (tokens.Length == 4)
                {
                    int displacement = int.Parse(tokens[2]);
                    string efficiency = tokens[3];
                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
            }

            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                string engineModel = tokens[1];
                Engine engine = new Engine(null, null);

                foreach (Engine eng in engines)
                {
                    if (eng.Model == engineModel)
                    {
                        engine = eng;
                    }
                }

                if (tokens.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (tokens.Length == 3)
                {
                    int weight;
                    bool isWeight = int.TryParse(tokens[2], out weight);
                    if (isWeight)
                    {
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        string color = tokens[2];
                        cars.Add(new Car(model, engine, color));
                    }
                }
                else if (tokens.Length == 4)
                {
                    int weight = int.Parse(tokens[2]);
                    string color = tokens[3];
                    cars.Add(new Car(model, engine, weight, color));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }

}
