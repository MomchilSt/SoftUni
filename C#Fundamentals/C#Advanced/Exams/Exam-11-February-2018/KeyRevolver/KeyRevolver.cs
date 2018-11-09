using System;
using System.Collections.Generic;
using System.Linq;

class KeyRevolver
{
    static void Main()
    {
        int bulletPrice = int.Parse(Console.ReadLine());
        int barrelSize = int.Parse(Console.ReadLine());

        int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] locks = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
        int allBullets = bullets.Length;

        Stack<int> bulletStack = new Stack<int>(bullets);
        Stack<int> lockStack = new Stack<int>(locks);

        int payout = int.Parse(Console.ReadLine());

        int reloadCount = 0;

        while (true)
        {

            int currBullet = bulletStack.Pop();
            int currLock = lockStack.Peek();

            if (currBullet <= currLock)
            {
                Console.WriteLine("Bang!");
                lockStack.Pop();
                reloadCount++;
            }
            else
            {
                Console.WriteLine("Ping!");
                reloadCount++;
            }

            if (reloadCount % barrelSize == 0 && bulletStack.Count > 0)
            {
                Console.WriteLine("Reloading!");
                reloadCount = 0;
            }


            if (lockStack.Count == 0 || bulletStack.Count == 0)
            {

                break;
            }
        }

        if (lockStack.Count != 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {lockStack.Count}");
        }
        else
        {
            int bulletsUsed = allBullets - bulletStack.Count;
            int bulletsCost = bulletsUsed * bulletPrice;

            Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${payout - bulletsCost}");
        }

    }
}