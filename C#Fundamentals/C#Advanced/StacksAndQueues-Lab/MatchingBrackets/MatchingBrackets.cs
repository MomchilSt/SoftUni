using System;
using System.Collections.Generic;

class MatchingBrackets
{
    static void Main()
    {
        string expression = Console.ReadLine();

        Stack<int> openBracketsIndexes = new Stack<int>();

        for (int i = 0; i < expression.Length; i++)
        {
            char element = expression[i];

            if (element == '(')
            {
                openBracketsIndexes.Push(i);
            }
            else if (element == ')')
            {
                int openBracketIndex = openBracketsIndexes.Pop();
                int bracketsLength = i - openBracketIndex + 1;
                string subExpression = expression.Substring(openBracketIndex, bracketsLength);

                Console.WriteLine(subExpression);
            }
        }
    }
}