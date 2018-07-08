using System;

class Program
{
    static void Main()
    {
        double kg = double.Parse(Console.ReadLine());
        string type = Console.ReadLine().ToLower();
        int distance = int.Parse(Console.ReadLine());

        double prize = 0;
        double express = 0;

        if (kg < 1)
        {
            if (type == "standard")
            {
                prize = distance * 0.03;
            }
            else
            {
                prize = distance * 0.03;
                express = 0.03 * 0.80;
                express = kg * express;
                prize = prize + (distance * express);
            }
        }

        if (kg >= 1 && kg <= 10)
        {
            if (type == "standard")
            {
                prize = distance * 0.05;
            }
            else
            {
                prize = distance * 0.05;
                express = 0.05 * 0.40;
                express = kg * express;
                prize = prize + (distance * express);
            }
        }


        if (kg >= 11 && kg <= 40)
        {
            if (type == "standard")
            {
                prize = distance * 0.10;
            }
            else
            {
                prize = distance * 0.10;
                express = 0.10 * 0.05;
                express = kg * express;
                prize = prize + (distance * express);
            }
        }


        if (kg >= 41 && kg <= 90)
        {
            if (type == "standard")
            {
                prize = distance * 0.15;
            }
            else
            {
                prize = distance * 0.15;
                express = 0.15 * 0.02;
                express = kg * express;
                prize = prize + (distance * express);
            }
        }


        if (kg >= 91 && kg <= 150)
        {
            if (type == "standard")
            {
                prize = distance * 0.20;
            }
            else
            {
                prize = distance * 0.20;
                express = 0.20 * 0.01;
                express = kg * express;
                prize = prize + (distance * express);
            }
        }

        Console.WriteLine($"The delivery of your shipment with weight of {kg:f3} kg. would cost {prize:f2} lv.");
    }
}
