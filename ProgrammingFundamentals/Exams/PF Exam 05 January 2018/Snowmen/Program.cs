using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();
        
        while (numbers.Count > 1)
        {
            List<int> lostNum = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers.Count(x => x != -1) == 1)
                {
                    break;  
                }

                if (numbers[i] == -1)
                {
                    continue;
                }

                int attacker = i;
                int target = numbers[i] % numbers.Count;
                int diff = Math.Abs(attacker - target);

                if (attacker == target)
                {
                    numbers[attacker] = -1;
                    Console.WriteLine($"{attacker} performed harakiri");
                    lostNum.Add(attacker);
                }
                else if (diff % 2 == 0)
                {
                    numbers[attacker] = -1;
                    Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                    lostNum.Add(target);
                    
                }
                else
                {
                    numbers[attacker] = -1;
                    Console.WriteLine($"{attacker} x {target} -> {target} wins");
                    lostNum.Add(attacker);
                }
            }

            numbers = numbers
                .Where(x => x != -1)
                .ToList();
        }
    }
}