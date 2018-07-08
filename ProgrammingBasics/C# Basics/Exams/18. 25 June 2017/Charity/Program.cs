using System;

class Program
{
    static void Main()
    {
        int days = int.Parse(Console.ReadLine());
        int sweets = int.Parse(Console.ReadLine());
        int cakes = int.Parse(Console.ReadLine());
        int waffles = int.Parse(Console.ReadLine());
        int pancakes = int.Parse(Console.ReadLine());

        double sweetsMoney = ((cakes * 45) + (waffles * 5.80) + (pancakes * 3.20)) * sweets;
        double total = sweetsMoney * days;
        Console.WriteLine($"{(total - (total/8)):f2}");
    }
}
