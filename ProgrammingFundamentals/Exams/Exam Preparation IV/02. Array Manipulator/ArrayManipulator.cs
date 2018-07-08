using System;
using System.Linq;

class ArrayManipulator
{
    static void Main()
    {
        int[] arr = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        while (true)
        {
            string[] input = Console.ReadLine().Split();

            if (input.First() == "end") { break; }

            string numType;
            int index;
            int count;
            int[] firstElems;
            int[] lastElems;
            switch (input.First())
            {
                case "exchange":
                    index = int.Parse(input[1]);
                    Exchange(ref arr, index);
                    break;
                case "max":
                    numType = input[1];
                    PrintMax(ref arr, numType);
                    break;
                case "min":
                    numType = input[1];
                    PrintMin(ref arr, numType);
                    break;
                case "first":
                    count = int.Parse(input[1]);
                    numType = input[2];

                    if (count <= arr.Length)
                    {
                        firstElems = GetFirstElems(ref arr, count, numType);
                        Console.WriteLine('[' + string.Join(", ", firstElems) + ']');
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                    break;
                case "last":
                    count = int.Parse(input[1]);
                    numType = input[2];

                    if (count <= arr.Length)
                    {
                        lastElems = GetLastElems(ref arr, count, numType);
                        Console.WriteLine('[' + string.Join(", ", lastElems) + ']');
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                    break;
            }
        }

        Console.WriteLine('[' + string.Join(", ", arr) + ']');
    }

    private static void Exchange(ref int[] arr, int index)
    {
        if (index < 0 || index >= arr.Length)
        {
            Console.WriteLine("Invalid index");
            return;
        }

        int[] firstArr = arr.Take(index + 1).ToArray();
        int[] secondArr = arr.Skip(index + 1).ToArray();

        arr = secondArr.Concat(firstArr).ToArray();
    }

    private static void PrintMax(ref int[] arr, string numType)
    {
        if (numType == "even")
        {
            if (arr.Where(x => x % 2 == 0).ToArray().Length > 0)
            {
                int maxEven = arr.Where(x => x % 2 == 0).Max();
                Console.WriteLine(arr.ToList().LastIndexOf(maxEven));
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
        else
        {
            if (arr.Where(x => x % 2 != 0).ToArray().Length > 0)
            {
                int maxOdd = arr.Where(x => x % 2 != 0).Max();
                Console.WriteLine(arr.ToList().LastIndexOf(maxOdd));
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }

    private static void PrintMin(ref int[] arr, string numType)
    {
        if (numType == "even")
        {
            if (arr.Where(x => x % 2 == 0).ToArray().Length > 0)
            {
                int minEven = arr.Where(x => x % 2 == 0).Min();
                Console.WriteLine(arr.ToList().LastIndexOf(minEven));
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
        else
        {
            if (arr.Where(x => x % 2 != 0).ToArray().Length > 0)
            {
                int minOdd = arr.Where(x => x % 2 != 0).Min();
                Console.WriteLine(arr.ToList().LastIndexOf(minOdd));
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }

    private static int[] GetFirstElems(ref int[] arr, int count, string numType)
    {
        if (numType == "even")
        {
            return arr.Where(x => x % 2 == 0).Take(count).ToArray();
        }
        else
        {
            return arr.Where(x => x % 2 != 0).Take(count).ToArray();
        }
    }

    private static int[] GetLastElems(ref int[] arr, int count, string numType)
    {
        if (numType == "even")
        {
            return arr.Reverse().Where(x => x % 2 == 0).Take(count).Reverse().ToArray();
        }
        else
        {
            return arr.Reverse().Where(x => x % 2 != 0).Take(count).Reverse().ToArray();
        }
    }
}
