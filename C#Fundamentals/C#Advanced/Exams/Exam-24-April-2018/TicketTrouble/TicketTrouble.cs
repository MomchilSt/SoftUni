using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class TicketTrouble
{
    static void Main()
    {
        string squarePattern = @"\[[^\]}]*{([A-Z]{3} [A-Z]{2})}[^\]}]*{([A-Z]{1}[0-9]{1,2})}[^{]*]";
        string currlyPattern = @"{[^}\]]*\[([A-Z]{3} [A-Z]{2})][^{}\]]*\[([A-Z]{1}\d{1,2})][^]\[]*}";


        string destination = Console.ReadLine();
        string input = Console.ReadLine();

        List<string> seats = new List<string>();

        var squareMatches = Regex.Matches(input, squarePattern);
        var currlyMatches = Regex.Matches(input, currlyPattern);

        FillSeats(seats, squareMatches, destination);
        FillSeats(seats, currlyMatches, destination);

        if (seats.Count > 2)
        {
            for (int i = 0; i < seats.Count; i++)
            {
                for (int j = i + 1; j < seats.Count; j++)
                {
                    string first = seats[i].Substring(1);
                    string second = seats[j].Substring(1);
                     
                    if (first == second)
                    {
                        Console.WriteLine($"You are traveling to {destination} on seats {seats[i]} and {seats[j]}.");
                        return;
                    }
                }
            }

            Console.WriteLine($"You are traveling to {destination} on seats {seats[0]} and {seats[1]}.");
            return;
        }
        else
        {

            Console.WriteLine($"You are traveling to {destination} on seats {seats[0]} and {seats[1]}.");
            return;
        }
    }

    private static void FillSeats(List<string> seats, MatchCollection matches, string destination)
    {
        foreach (Match match in matches)
        {
            if (match.Groups[1].Value == destination)
            {
                seats.Add(match.Groups[2].Value);
            }

            if (match.Groups[3].Value == destination)
            {
                seats.Add(match.Groups[4].Value);
            }
        }
    }
}