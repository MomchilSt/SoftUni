using System;

class Trainers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double technicalIncome = 0;
        double theoreticalIncome = 0;
        double practicalIncome = 0;

        for (int i = 0; i < n; i++)
        {
            int distanceM = int.Parse(Console.ReadLine()) * 1600;
            double cargoKg = double.Parse(Console.ReadLine()) * 1000;
            string participant = Console.ReadLine();

            double totalIncome = (1.5 * cargoKg) - (0.7 * distanceM * 2.5);

            switch (participant)
            {
                case "Technical":
                    technicalIncome += totalIncome;
                    break;
                case "Theoretical":
                    theoreticalIncome += totalIncome;
                    break;
                case "Practical":
                    practicalIncome += totalIncome;
                    break;
            }
        }

        if (technicalIncome > theoreticalIncome && technicalIncome > practicalIncome)
        {
            Console.WriteLine($"The Technical Trainers win with ${technicalIncome:F3}.");
        }
        else if (theoreticalIncome > technicalIncome && theoreticalIncome > practicalIncome)
        {
            Console.WriteLine($"The Theoretical Trainers win with ${theoreticalIncome:F3}.");
        }
        else if (practicalIncome > technicalIncome && practicalIncome > technicalIncome)
        {
            Console.WriteLine($"The Practical Trainers win with ${practicalIncome:F3}.");
        }
    }
}
