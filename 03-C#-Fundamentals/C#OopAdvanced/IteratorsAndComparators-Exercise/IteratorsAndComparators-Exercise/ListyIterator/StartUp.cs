using System;
using System.Linq;

namespace ListyIterator
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
                string[] arguments = inputArgs.Skip(1).ToArray();

                switch (command)
                {
                    case "Create":
                        listyIterator = new ListyIterator<string>(arguments);
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
                    default:
                        throw new ArgumentException();
                }
                input = Console.ReadLine();
            }
        }
    }
}
