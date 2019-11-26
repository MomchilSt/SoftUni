using System;
using System.Collections.Generic;
using System.Linq;

class BalancedParanthesis
{
    static void Main()
    {
        string parentheses = Console.ReadLine();

        var stackOfParentheses = new Stack<char>();

        char[] openParantheses = new char[] { '(', '[', '{' };

        bool isValid = true;

        for (int i = 0; i < parentheses.Length; i++)
        {
            char currentBraket = parentheses[i];

            if (openParantheses.Contains(currentBraket))
            {
                stackOfParentheses.Push(currentBraket);
                continue;
            }

            if (stackOfParentheses.Count == 0)
            {
                isValid = false;
                break;
            }

            if (currentBraket == ')' && stackOfParentheses.Peek() == '(')
            {
                stackOfParentheses.Pop();
            }
            else if (currentBraket == ']' && stackOfParentheses.Peek() == '[')
            {
                stackOfParentheses.Pop();
            }
            else if (currentBraket == '}' && stackOfParentheses.Peek() == '{')
            {
                stackOfParentheses.Pop();
            }
        }

        if (isValid && stackOfParentheses.Count == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}