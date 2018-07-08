using System;

class Program
{
    static void Main()
    {
        int pictures = int.Parse(Console.ReadLine());
        string type = Console.ReadLine().ToLower();
        string OnOrOff = Console.ReadLine().ToLower();

        double prize = 0;

        switch (type)
        {
            case "9x13":
                if (pictures <= 50)
                {
                    prize = pictures * 0.16;
                }
                else if (pictures > 50)
                {
                    prize = pictures * 0.16;
                    prize = prize - (prize * 0.05);
                }
                break;

            case "10x15":
                if (pictures <= 80)
                {
                    prize = pictures * 0.16;
                }
                else if (pictures > 80)
                {
                    prize = pictures * 0.16;
                    prize = prize - (prize * 0.03);
                }
                break;

            case "13x18":
                if (pictures < 50)
                {
                    prize = pictures * 0.38;
                }
                else if (pictures >= 50 && pictures <= 100)
                {
                    prize = pictures * 0.38;
                    prize = prize - (prize * 0.03);
                }
                else if (pictures > 100)
                {
                    prize = pictures * 0.38;
                    prize = prize - (prize * 0.05);
                }
                break;

            case "20x30":
                if (pictures < 10)
                {
                    prize = pictures * 2.90;
                }
                else if (pictures >= 10 && pictures <= 50)
                {
                    prize = pictures * 2.90;
                    prize = prize - (prize * 0.07);
                }
                else if (pictures > 50)
                {
                    prize = pictures * 2.90;
                    prize = prize - (prize * 0.09);
                }
                break;
        }

        if (OnOrOff == "online")
        {
            prize = prize - (prize * 0.02);
            Console.WriteLine($"{prize:f2}BGN");
        }
        else
        {
            Console.WriteLine($"{prize:f2 }BGN");
        }
    }
}
