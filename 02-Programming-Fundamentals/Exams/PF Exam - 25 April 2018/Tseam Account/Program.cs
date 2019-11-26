using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> gameList = Console.ReadLine()
            .Split()
            .ToList();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Play!")
            {
                break;
            }

            string[] tokens = input.Split();
            string commands = tokens[0];
            string game = tokens[1];

            if (commands == "Install")
            {
                if (!gameList.Contains(game))
                {
                    gameList.Add(game);
                }
            }
            else if (commands == "Uninstall")
            {
                if (gameList.Contains(game))
                {
                    gameList.Remove(game);
                }
            }
            else if (commands == "Update")
            {
                if (gameList.Contains(game))
                {
                    string temp = game;
                    gameList.Remove(game);
                    gameList.Add(temp);
                }
            }
            else if (commands == "Expansion")
            {
                string[] expansion = game.Split("-");
                string gameName = expansion[0];
                string expansionName = expansion[1];

                if (gameList.Contains(gameName))
                {
                    int index = gameList.IndexOf(gameName);
                    gameList.Insert(index + 1, $"{gameName}:{expansionName}");
                }
            }
        }
        Console.WriteLine(string.Join(" ", gameList));
    }
}

/*
 
                        for (int i = 0; i < gameList.Count; i++)
                    {
                        if (gameList[i] == gameName)
                        {
                            gameList.Insert(i, $"{gameName}:{expansionName}");
                        }
                    }

 * */
