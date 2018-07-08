using System;

class Program
{
    static void Main()
    {
        string fruit = Console.ReadLine().ToLower();
        string size = Console.ReadLine().ToLower();
        int numOfDrinks = int.Parse(Console.ReadLine());

        double total = 0;

        switch (fruit)
        {
            case "watermelon":
                if (size == "small")
                {
                    total = 2 * 56;
                    total *= numOfDrinks;
                }
                else if (size == "big")
                {
                    total = 5 * 28.70;
                    total *= numOfDrinks;
                }
                break;
            //----------------------------------------------------------
            case "mango":
                if (size == "small")
                {
                    total = 2 * 36.66;
                    total *= numOfDrinks;
                }
                else if (size == "big")
                {
                    total = 5 * 19.60;
                    total *= numOfDrinks;
                }
                break;
            //-----------------------------------------------------------
            case "pineapple":
                if (size == "small")
                {
                    total = 2 * 42.10;
                    total *= numOfDrinks;
                }
                else if (size == "big")
                {
                    total = 5 * 24.80;
                    total *= numOfDrinks;
                }
                break;
            //------------------------------
            case "raspberry":
                if (size == "small")
                {
                    total = 2 * 20;
                    total *= numOfDrinks;
                }
                else if (size == "big")
                {
                    total = 5 * 15.20;
                    total *= numOfDrinks;
                }
                break;
        }

        if (total > 1000)
        {
            total = total - (total * 0.50);
            Console.WriteLine($"{total:f2} lv.");
        }
        else if (total >= 400 && total < 1000)
        {
            total = total - (total * 0.15);
            Console.WriteLine($"{total:f2} lv.");
        }
        else
        {
            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
