using System;

class Program
{
    static void Main()
    {
        int peshosDmg = int.Parse(Console.ReadLine());
        int goshosDmg = int.Parse(Console.ReadLine());

        int counter = 0;
        int peshoHp = 100;
        int goshoHp = 100;

        while (true)
        {
            counter++;
            if (counter % 2 != 0)
            {
                goshoHp -= peshosDmg;
                if (goshoHp <= 0)
                {
                    break;
                }
                Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHp} health.");
            }
            else
            {
                peshoHp -= goshosDmg;
                if (peshoHp <= 0)
                {
                    break;
                }
                Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHp} health.");

            }
            if (counter % 3 == 0)
            {
                peshoHp += 10;
                goshoHp += 10;
            }
        }
        if (peshoHp > goshoHp)
        {
            Console.WriteLine($"Pesho won in {counter}th round.");
        }
        else
        {
            Console.WriteLine($"Gosho won in {counter}th round.");
        }
    }
}
