using System;
using System.Collections;
using System.Collections.Generic;

class Crossroads
{
    static void Main()
    {
        var stopLight = new Queue<string>();

        int greenLight = int.Parse(Console.ReadLine());
        int freeWindow = int.Parse(Console.ReadLine());
        int passedCars = 0;

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            if (input != "green")
            {
                stopLight.Enqueue(input);
                continue;
            }

            int currentLight = greenLight;
            string currCar = string.Empty;
            string outputCar = string.Empty;

            while (stopLight.Count > 0 && currentLight > 0)
            {
                currCar = stopLight.Dequeue();
                outputCar = currCar;
                currentLight -= currCar.Length;

                if (currentLight >= 0)
                {
                    passedCars++;
                    continue;
                }

                currCar = currCar.Remove(0, currCar.Length - currentLight * -1);

                currentLight += freeWindow;

                if (currentLight >= 0)
                {
                    passedCars++;
                    break;
                }

                currCar = currCar.Remove(0, currCar.Length - currentLight * -1);
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{outputCar} was hit at {currCar[0]}.");
                return;
            }
        }

        Console.WriteLine("Everyone is safe.");
        Console.WriteLine($"{passedCars} total cars passed the crossroads.");
    }

}