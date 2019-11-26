using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class KeyRevolverV2
{
    static void Main()
    {
        int bulletPrice = int.Parse(Console.ReadLine());
        int gunSize = int.Parse(Console.ReadLine());
        var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        int intelligence = int.Parse(Console.ReadLine());

        int bulletsLenght = bullets.Count;
        int counter = 0;
        int bulletsCounter = 0;

        while (bullets.Count != 0 || locks.Count != 0)
        {
            int currBullet = bullets.Pop();
            int currLock = locks.Peek();

            counter++;
            bulletsCounter++;

            if (currBullet <= currLock)
            {
                locks.Dequeue();
                Console.WriteLine("Bang!");
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            if (counter == gunSize && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
                counter = 0;
            }

            if (bullets.Count == 0 || locks.Count == 0)
            {
                break;
            }
        }

        int bulletsCost = bulletsCounter * bulletPrice;
        int bulletsLeft = bulletsLenght - bulletsCounter;

        if (locks.Count != 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
        else
        {
            Console.WriteLine($"{bulletsLeft} bullets left. Earned ${intelligence - bulletsCost}");
        }
    }
}