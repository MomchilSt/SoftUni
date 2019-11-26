using System;

class Program
{
    static void Main()
    {
        int rounds = int.Parse(Console.ReadLine());

        double result = 0;
        double sum = 0;

        double pointsTwo = 0;
        double pointsThree = 0;
        double pointsFour = 0;
        double pointsFive = 0;
        double pointsSix = 0;
        double pointsSeven = 0;

        for (int i = 0; i < rounds; i++)
        {
            int counter = int.Parse(Console.ReadLine());

            if (counter >= 0 && counter <= 9 )
            {
                pointsTwo++;
                sum = counter * 0.20;
                result += sum;
            }
            else if (counter >= 10 && counter <= 19)
            {
                pointsThree++;
                sum = counter * 0.30;
                result += sum;
            }
            else if (counter >= 20 && counter <= 29)
            {
                pointsFour++;
                sum = counter * 0.40;
                result += sum;
            }
            else if (counter >= 30 && counter <= 39)
            {
                pointsFive++;
                result += 50;
            }
            else if (counter >= 40 && counter <= 50)
            {
                pointsSix++;
                result += 100; 
            }
            else
            {
                pointsSeven++;
                result /= 2;
            }
        }

        Console.WriteLine($"{result:f2}");
        Console.WriteLine("From 0 to 9: {0:f2}%", (pointsTwo / rounds) * 100);
        Console.WriteLine("From 10 to 19: {0:f2}%", (pointsThree / rounds) * 100);
        Console.WriteLine("From 20 to 29: {0:f2}%", (pointsFour / rounds) * 100);
        Console.WriteLine("From 30 to 39: {0:f2}%", (pointsFive / rounds) * 100);
        Console.WriteLine("From 40 to 50: {0:f2}%", (pointsSix / rounds) * 100);
        Console.WriteLine("Invalid numbers: {0:f2}%", (pointsSeven / rounds) * 100);
    }
}
