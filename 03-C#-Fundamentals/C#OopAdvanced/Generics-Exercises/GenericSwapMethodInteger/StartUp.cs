using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        public static void Main()
        {
            List<Box<int>> boxes = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                boxes.Add(new Box<int>(input));
            }

            var indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            Swap(boxes, indexes[0], indexes[1]);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        static void Swap<T>(IList<Box<T>> list, int index1, int index2)
        {
            Box<T> temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}