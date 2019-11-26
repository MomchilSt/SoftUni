using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GreedyTimesV2
{
    static void Main()
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] itemsInput = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var goldBag = new Dictionary<string, long>();
        long goldQuantity = 0;

        var gemBag = new Dictionary<string, long>();
        long gemQuantity = 0;

        var cashBag = new Dictionary<string, long>();
        long cashQuantity = 0;

        for (int i = 0; i < itemsInput.Length; i+= 2)
        {
            string itemName = itemsInput[i];
            long itemAmount = long.Parse(itemsInput[i + 1]);

            string itemType = GetItem(itemName);
            bool canInsertItem = CanPutItemInBag(itemType, itemAmount, bagCapacity, goldQuantity, gemQuantity, cashQuantity);

            if (itemType == "Invalid" || !canInsertItem)
            {
                continue;
            }


            switch (itemType)
            {
                case "Gold":
                    InsertItem(goldBag, itemName, itemAmount);
                    goldQuantity += itemAmount;
                    break;

                case "Gem":
                    InsertItem(gemBag, itemName, itemAmount);
                    gemQuantity += itemAmount;
                    break;

                case "Cash":
                    InsertItem(cashBag, itemName, itemAmount);
                    cashQuantity += itemAmount;
                    break;
            }
        }

        if (goldBag.Any())
        {
            Console.WriteLine(PrintBag(goldBag, "Gold", goldQuantity));

            if (gemBag.Any())
            {
                Console.WriteLine(PrintBag(gemBag, "Gem", gemQuantity));

                if (cashBag.Any())
                {
                    Console.WriteLine(PrintBag(cashBag, "Cash", cashQuantity));
                }
            }
        }
    }

    private static string PrintBag(Dictionary<string, long> bag, string type, long quantity)
    {
        var resultBuilder = new StringBuilder();

        resultBuilder.AppendLine($"<{type}> ${quantity}");

        var orderedBag = bag.OrderByDescending(x => x.Key).ThenBy(x => x.Value);

        foreach (var item in orderedBag)
        {
            resultBuilder.AppendLine($"##{item.Key} - {item.Value}");
        }

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

    private static void InsertItem(Dictionary<string, long> bag, string itemName, long itemAmount)
    {
        if (bag.ContainsKey(itemName) == false)
        {
            bag[itemName] = 0;
        }

        bag[itemName] += itemAmount;
    }

    private static bool CanPutItemInBag(string itemType, long itemAmount, long bagCapacity, long goldQuantity, long gemQuantity, long cashQuantity)
    {

        long bagCurrent = goldQuantity + gemQuantity + cashQuantity;

        if (bagCapacity < bagCurrent + itemAmount)
        {
            return false;
        }

        switch (itemType)
        {
            case "Gold":
                return true;
            case "Gem":
                gemQuantity += itemAmount;
                return gemQuantity <= goldQuantity;
            case "Cash":
                cashQuantity += itemAmount;
                return cashQuantity <= gemQuantity;
        }
        return false;
    }

    private static string GetItem(string itemName)
    {
        if (itemName.Length == 3)
        {
            return "Cash";
        }

        if (itemName.ToLower().EndsWith("gem") && itemName.Length >= 4)
        {
            return "Gem";
        }

        if (itemName.ToLower() == "gold")
        {
            return "Gold";
        }

        return "Invalid";
    }
}