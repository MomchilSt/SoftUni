using System;

class Cinema
{
    static void Main()
    {
        string projection = Console.ReadLine().ToLower();
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());

        double price = 0.0;

        if (projection == "premiere")
            price = rows * columns * 12.00;
        else if (projection == "normal")
            price = rows * columns * 7.50;
        else if (projection == "discount")
            price = rows * columns * 5.00;

        Console.WriteLine("{0:f2}", price);
    }
}
