using System;

class Program
{
    static void Main()
    {
        short bandMembers = short.Parse(Console.ReadLine());
        float guitarPrice = float.Parse(Console.ReadLine());

        int numberOfGuitarists = bandMembers / 3;
        int numberOfDrummbers = bandMembers - 1 - numberOfGuitarists;

        float guitaristMoney = numberOfGuitarists * guitarPrice;

        float drumPrice = guitarPrice * 1.50f * numberOfDrummbers;
        float micPrice = drumPrice - guitaristMoney;


        float rent = ((drumPrice + micPrice + guitaristMoney) / bandMembers) * 12;

        float total = rent + micPrice + drumPrice + guitaristMoney;

        Console.WriteLine("Total cost: {0:f2}lv.", total);
    }
}
