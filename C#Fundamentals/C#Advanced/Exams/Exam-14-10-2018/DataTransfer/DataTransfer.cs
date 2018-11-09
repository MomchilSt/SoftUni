using System;
using System.Text.RegularExpressions;

class DataTransfer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string pattern = "s:([^;]+);r:([^;]+);m--\"([a-zA-Z\\s]+)\"";


        string resultSender = string.Empty;
        string resultReciever = string.Empty;
        string resultMessage = string.Empty;

        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern);

            string sender = string.Empty;
            string reciever = string.Empty;
            string message = string.Empty;

            foreach (Match match in matches)
            {
                sender = match.Groups[1].Value;
                reciever = match.Groups[2].Value;
                message = match.Groups[3].Value;
                resultMessage = message;

                for (int m1 = 0; m1 < sender.Length; m1++)
                {
                    if (char.IsLetter(sender[m1]) || sender[m1] == ' ')
                    {
                        resultSender += sender[m1];
                    }

                    sum += Digit(sender[m1]);
                }

                for (int m1 = 0; m1 < reciever.Length; m1++)
                {
                    if (char.IsLetter(reciever[m1]) || reciever[m1] == ' ')
                    {
                        resultReciever += reciever[m1];
                    }

                    sum += Digit(reciever[m1]);
                }
                Console.WriteLine(resultSender + " says " + $"\"{resultMessage}\"" + " to " + resultReciever);
                resultSender = string.Empty;
                resultReciever = string.Empty;
            }
        }


        Console.WriteLine($"Total data transferred: {sum}MB");
    }

    private static int Digit(char curr)
    {
        switch (curr)
        {
            case '1':
                return 1;

            case '2':
                return 2;

            case '3':
                return 3;

            case '4':
                return 4;

            case '5':
                return 5;

            case '6':
                return 6;

            case '7':
                return 7;

            case '8':
                return 8;

            case '9':
                return 9;
            default:

                return 0;
        }
    }
}