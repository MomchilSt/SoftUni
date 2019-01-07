using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Push":
                        int[] elements = tokens.Skip(1)
                            .Select(i => i.Split(',').First())
                            .Select(int.Parse)
                            .ToArray();

                        stack.Push(elements);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
