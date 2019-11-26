using System;

class Program
{
    static void Main()
    {
        int needHours = int.Parse(Console.ReadLine());
        int worker = int.Parse(Console.ReadLine());
        int workDays = int.Parse(Console.ReadLine());

        int total = worker * (workDays * 8);

        if (needHours < total)
        {
            int fill = total - needHours;
            Console.WriteLine($"{fill} hours left");
        }
        else
        {
            int fill = needHours - total;
            int fillSecond = fill * workDays;
            Console.WriteLine($"{fill} overtime");
            Console.WriteLine($"Penalties: {fillSecond}");
        }


    }
}
