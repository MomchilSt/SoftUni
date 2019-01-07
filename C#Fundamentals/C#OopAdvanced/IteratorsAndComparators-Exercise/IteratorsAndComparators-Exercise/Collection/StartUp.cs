using System;
using System.Linq;

namespace Collection
{
    public class StartUp
    {
        public static void Main()
        {
            ListyIterator<string> listyIterator = null;

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split();

                string command = inputArgs[0];

                switch (command)
                {
                    case "Create":
                        listyIterator = new ListyIterator<string>(inputArgs.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "PrintAll":
                        foreach (var item in listyIterator)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
