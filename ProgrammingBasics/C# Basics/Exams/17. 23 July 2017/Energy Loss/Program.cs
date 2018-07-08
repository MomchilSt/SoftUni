using System;

class Program
{
    static void Main()
    {
        int trainDays = int.Parse(Console.ReadLine());
        int dancers = int.Parse(Console.ReadLine());

        double total = 0;

        for (int i = 1; i <= trainDays; i++)
        {
            double hours = double.Parse(Console.ReadLine());

            if (i % 2 == 0 && hours % 2 == 0)
            {
                total += 68 * dancers;
            }
            else if (i % 2 != 0 && hours % 2 == 0)
            {
                total += 49 * dancers;
            }
            else if (i % 2 == 0 && hours % 2 != 0)
            {
                total += 65 * dancers;
            }
            else if (i % 2 != 0 && hours % 2 != 0)
            {
                total += 30 * dancers;
            }
        }
        
        double totalEnergy = 100 * trainDays * dancers;
        double notUsedEnergy = totalEnergy - total;

        double energyPerPerson = (notUsedEnergy / trainDays) / dancers;

        if (energyPerPerson >= 50)
        {
            Console.WriteLine($"They feel good! Energy left: {energyPerPerson:f2}");
        }
        else
        {
            Console.WriteLine($"They are wasted! Energy left: {energyPerPerson:f2}");
        }
    }
}
