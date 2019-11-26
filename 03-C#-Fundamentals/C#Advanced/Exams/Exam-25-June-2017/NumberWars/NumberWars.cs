using System;
using System.Collections.Generic;
using System.Linq;

class NumberWars
{
    static int turnsCounter = 0;

    static void Main()
    {
        var firstCards = new Queue<string>(Console.ReadLine().Split());
        var secondCards = new Queue<string>(Console.ReadLine().Split());

        var letterScore = new Dictionary<char, int>();
        for (char i = 'a'; i <= 'z'; i++)
        {
            int currScore = 1;
            letterScore.Add(i, i - 96);
            currScore++;
        }

        List<string> winningPool = new List<string>();
        bool firstWins = false;
        bool secondWins = false;
        bool noDrow = false;

        while (true)
        {
            if (firstCards.Count == 0 || secondCards.Count == 0)
            {
                break;
            }

            string currentFirst = firstCards.Dequeue();
            string currentSecond = secondCards.Dequeue();

            turnsCounter++;

            if (turnsCounter == 1000000)
            {
                Console.WriteLine($"Draw after {turnsCounter} turns");
                Environment.Exit(0);
            }

            noDrow = CalculateScore(currentFirst, currentSecond, firstCards, secondCards, winningPool, letterScore, turnsCounter, firstWins, secondWins, noDrow);
            if (noDrow)
            {
                continue;
            }


            winningPool.Add(currentFirst);
            winningPool.Add(currentSecond);

            int firstSum = 0;
            int secondSum = 0;

            while (true)
            {
                if (firstSum > secondSum)
                {
                    firstWins = true;
                    break;
                }
                if (secondSum > firstSum)
                {
                    secondWins = true;
                    break;
                }

                for (int draws = 0; draws < 3; draws++)
                {
                    if (firstCards.Count == 0 || secondCards.Count == 0 || turnsCounter == 1000000)
                    {
                        Console.WriteLine($"Draw after {turnsCounter} turns");
                        Environment.Exit(0);
                    }
                    string firstDraw = firstCards.Dequeue();
                    string secondDraw = secondCards.Dequeue();

                    winningPool.Add(firstDraw);
                    winningPool.Add(secondDraw);

                    char firstChar = firstDraw[firstDraw.Length - 1];
                    char secondChar = secondDraw[secondDraw.Length - 1];

                    firstSum += letterScore[firstChar];
                    secondSum += letterScore[secondChar];
                }
            }


            if (firstWins)
            {
                foreach (var num in winningPool.OrderByDescending(x => GetNumber(x)).ThenByDescending(x => GetChar(x)))
                {
                    firstCards.Enqueue(num);
                }
            }
            else
            {
                foreach (var num in winningPool.OrderByDescending(x => GetNumber(x)).ThenByDescending(x => GetChar(x)))
                {
                    secondCards.Enqueue(num);
                }
            }


        }

        if (firstWins || secondCards.Count == 0)
        {
            Console.WriteLine($"First player wins after {turnsCounter} turns");
        }
        else
        {
            Console.WriteLine($"Second player wins after {turnsCounter} turns");
        }
    }

    private static bool CalculateScore(string currentFirst, string currentSecond, Queue<string> firstCards, Queue<string> secondCards, List<string> winningPool, Dictionary<char, int> letterScore,int turnsCounter, bool firstWins, bool secondWins, bool noDraw)
    {
        int firstNum = int.Parse(currentFirst.Substring(0,currentFirst.Length - 1));
        int secondNum = int.Parse(currentSecond.Substring(0, currentSecond.Length - 1));

        if (firstNum > secondNum)
        {
            firstCards.Enqueue(currentFirst);
            firstCards.Enqueue(currentSecond);
            return noDraw = true;
        }
        else if (secondNum > firstNum)
        {
            secondCards.Enqueue(currentSecond);
            secondCards.Enqueue(currentFirst);
            return noDraw = true;
        }
        else
        {
            return noDraw = false;
        }
    }

    static int GetNumber(string card)
    {
        return int.Parse(card.Substring(0, card.Length - 1));
    }

    static char GetChar(string card)
    {
        return card[card.Length - 1];
    }
}