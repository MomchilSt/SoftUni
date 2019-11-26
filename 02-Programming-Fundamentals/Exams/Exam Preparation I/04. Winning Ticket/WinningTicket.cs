using System;

class WinningTicket
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string ticket in input)
        {
            if (ticket.Length != 20)
            {
                Console.WriteLine("invalid ticket");
                continue;
            }

            string firstHalf = ticket.Substring(0, 10);
            string secondHalf = ticket.Substring(10);

            char[] winingSymbols = new char[] { '@', '#', '$', '^' };
            bool hasMatch = false;
            foreach (char symb in winingSymbols)
            {
                for (int i = 10; i >= 6; i--)
                {
                    if (firstHalf.Contains(new string(symb, i)) && secondHalf.Contains(new string(symb, i)))
                    {
                        if (i == 10) { Console.WriteLine($"ticket \"{ticket}\" - 10{symb} Jackpot!"); }
                        else { Console.WriteLine($"ticket \"{ticket}\" - {i}{symb}"); }
                        hasMatch = true;
                        break;
                    }

                    if (hasMatch) { break; }
                }
            }

            if (!hasMatch) { Console.WriteLine($"ticket \"{ticket}\" - no match"); }
        }
    }
}
