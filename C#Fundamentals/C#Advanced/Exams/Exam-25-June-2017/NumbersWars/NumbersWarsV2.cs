using System;
using System.Collections.Generic;
using System.Linq;

class NumbersWarsV2
{
    static void Main()
    {
        var firstCards = new Queue<string>(Console.ReadLine().Split());
        var secondCards = new Queue<string>(Console.ReadLine().Split());

        var turnCounter = 0;
        bool gameOver = false;

        while (turnCounter < 1000000 && firstCards.Count > 0 && secondCards.Count > 0 && !gameOver)
        {
            turnCounter++;

            var firstCard = firstCards.Dequeue();
            var secondCard = secondCards.Dequeue();

            if (GetNumber(firstCard) > GetNumber(secondCard))
            {
                firstCards.Enqueue(firstCard);
                firstCards.Enqueue(secondCard);
            }
            else if (GetNumber(firstCard) < GetNumber(secondCard))
            {
                secondCards.Enqueue(secondCard);
                secondCards.Enqueue(firstCard);
            }
            else
            {
                var winningPool = new List<string>();
                winningPool.Add(firstCard);
                winningPool.Add(secondCard);

                while (!gameOver)
                {
                    if (firstCards.Count >= 3 && secondCards.Count >= 3)
                    {
                        int firstSum = 0;
                        int secondSum = 0;

                        for (int counter = 0; counter < 3; counter++)
                        {
                            var firstHand = firstCards.Dequeue();
                            var secondHand = secondCards.Dequeue();
                            firstSum += GetChar(firstHand);
                            secondSum += GetChar(secondHand);

                            winningPool.Add(firstHand);
                            winningPool.Add(secondHand);
                        }

                        if (firstSum > secondSum)
                        {
                            AddCardsToWinner(firstCards, winningPool);
                            break;
                        }
                        else if (firstSum < secondSum)
                        {
                            AddCardsToWinner(secondCards, winningPool);
                            break;
                        }
                    }
                    else
                    {
                        gameOver = true;
                    }
                }
            }
        }

        if (firstCards.Count == secondCards.Count)
        {
            Console.WriteLine($"Draw after {turnCounter} turns");
        }
        else if (firstCards.Count > secondCards.Count)
        {
            Console.WriteLine($"First player wins after {turnCounter} turns");
        }
        else
        {
            Console.WriteLine($"Second player wins after {turnCounter} turns");
        }
    }

    private static void AddCardsToWinner(Queue<string> winner, List<string> winningPool)
    {
        foreach (var card in winningPool.OrderByDescending(x => GetNumber(x)).ThenByDescending(x => GetChar(x)))
        {
            winner.Enqueue(card);
        }
    }

    static int GetNumber(string card)
    {
        return int.Parse(card.Substring(0, card.Length - 1));
    }

    static char GetChar(string card)
    {
        return card[card.Length-1];
    }
}