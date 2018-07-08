using System;
using System.Collections.Generic;
using System.Linq;

class PokemonDontGo
{
    static void Main()
    {
        List<int> nums = Console.ReadLine()
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToList();

        List<int> removed = new List<int>();

        int indexedNum = 0;
        while (nums.Count > 0)
        {
            int index = int.Parse(Console.ReadLine());

            if (index < 0)
            {
                indexedNum = nums[0];

                removed.Add(nums[0]);
                nums[0] = nums[nums.Count - 1];
            }
            else if (index >= nums.Count)
            {
                indexedNum = nums[nums.Count - 1];

                removed.Add(nums[nums.Count - 1]);
                nums[nums.Count - 1] = nums[0];
            }
            else
            {
                indexedNum = nums[index];

                removed.Add(indexedNum);
                nums.RemoveAt(index);
            }

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] <= indexedNum)
                {
                    nums[i] += indexedNum;
                }
                else if (nums[i] > indexedNum)
                {
                    nums[i] -= indexedNum;
                }
            }
        }

        Console.WriteLine(removed.Sum());
    }
}
