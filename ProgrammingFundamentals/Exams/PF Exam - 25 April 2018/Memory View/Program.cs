using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        while (true)
        {
            List<string> words = new List<string>();

            string input = Console.ReadLine();

            if (input == "Visual Studio crash")
            {
                break;
            }

            string[] tokens = input.Split();
            int counter = 0;
            int wordLenght = 0;

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "32763")
                {
                    counter++;
                    wordLenght = int.Parse(tokens[i + 2]);
                    i += 4;
                    for (int j = 0; j < wordLenght; j++)
                    {
                        words.Add(tokens[i]);
                            i++;
                    }
                }
            }

            foreach (var item in words)
            {
                char temp = Convert.ToChar(Convert.ToInt32(item));
                Console.Write(temp);
            }
            Console.WriteLine();
        }
    }
}
