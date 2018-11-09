using System;
using System.Collections;
using System.Collections.Generic;

class SimpleTextEditor
{
    static void Main()
    {
        Stack<string> stack = new Stack<string>();

        string text = string.Empty;

        int operations = int.Parse(Console.ReadLine());

        for (int i = 0; i < operations; i++)
        {
            string[] input = Console.ReadLine().Split();

            string currentCommand = input[0];

            switch (currentCommand)
            {
                case "1":
                    string currentText = input[1];
                    stack.Push(text);

                    text += currentText;
                    break;

                case "2":
                    int count = int.Parse(input[1]);

                    if (count > text.Length)
                    {
                        count = Math.Min(count, text.Length);
                    }

                    stack.Push(text);
                    text = text.Substring(0, text.Length - count);
                    break;

                case "3":
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);
                    break;

                case "4":
                    text = stack.Pop();
                    break;
            }
        }
    }
}