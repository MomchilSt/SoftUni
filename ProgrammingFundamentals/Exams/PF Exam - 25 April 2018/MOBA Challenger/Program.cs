using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, int>> register = new Dictionary<string, Dictionary<string, int>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Season end")
            {
                break;
            }
            //Loop Break;

            string[] tokens = input.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

            // When we add to the register;
            if (input.Contains("->"))                           
            {
                string playerName = tokens[0];
                string playerPosition = tokens[1];
                int skilPoints = int.Parse(tokens[2]);

                // player name not registered
                if (register.ContainsKey(playerName) == false)        
                {
                    register.Add(playerName, new Dictionary<string, int>());
                }

                // exsisting player has new position
                if (register[playerName].ContainsKey(playerPosition) == false) 
                {
                    register[playerName].Add(playerPosition, skilPoints);
                }

                // exsisting player with existant positon but higher skill
                if (register[playerName].ContainsKey(playerPosition))
                {
                    int oldSkill = register[playerName][playerPosition];

                    if (oldSkill < skilPoints)
                    {
                        register[playerName][playerPosition] = skilPoints;
                    }
                }
            }
            // Commnad PvP is called
            else if (input.Contains("vs"))
            {
                string[] tokenss = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string firstDuelist = tokenss[0];
                string secondDuelist = tokenss[2];

                if (register.ContainsKey(firstDuelist) && register.ContainsKey(secondDuelist))
                {
                    string playerToRemove = string.Empty;

                    foreach (var role in register[firstDuelist])
                    {
                        foreach (var posi in register[secondDuelist])
                        {
                            if (role.Key == posi.Key)
                            {
                                if (register[firstDuelist].Values.Sum() > register[secondDuelist].Values.Sum())
                                {
                                    playerToRemove = secondDuelist;
                                }
                                else if (register[firstDuelist].Values.Sum() < register[secondDuelist].Values.Sum())
                                {
                                    playerToRemove = firstDuelist;
                                }
                            }
                        }
                    }
                    register.Remove(playerToRemove);
                }
            }
        }
        //Printing 
        foreach (var player in register.OrderByDescending(x => x.Value.Values.Sum()))
        {
            Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

            foreach (var pair in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"- {pair.Key} <::> {pair.Value}");
            }
        }
    }
}