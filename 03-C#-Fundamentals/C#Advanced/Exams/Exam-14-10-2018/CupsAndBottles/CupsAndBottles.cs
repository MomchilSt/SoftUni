using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class CupsAndBottles
{
    static void Main()
    {
        var cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray().Reverse();
        var bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var cups = new Stack<int>(cupsInput);
        var bottles = new Stack<int>(bottlesInput);

        int wastedWater = 0;


        while (true)
        {
            if (cups.Count == 0 || bottles.Count == 0)
            {
                break;
            }

            int currCup = cups.Pop();
            int currBottle = bottles.Pop();

            if (currBottle >= currCup)
            {
                wastedWater += currBottle - currCup;

                if (cups.Count == 0)
                {
                    break;
                }
            }
            else
            {
                currCup -= currBottle;

                while (currCup >= 0)
                {
                    if (bottles.Count == 0)
                    {
                        break;
                    }

                    int nextBot = bottles.Pop();

                    if (nextBot >= currCup)
                    {
                        nextBot -= currCup;
                        wastedWater += nextBot;
                        break;
                    }

                    currCup -= nextBot;
                }
            }
        }


        if (cups.Count == 0)
        {
            Console.WriteLine($"Bottles: {bottles.Sum()}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
        else
        {
            Console.Write($"Cups: ");
            while (cups.Count != 0)
            {
                Console.Write(cups.Pop() + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
 