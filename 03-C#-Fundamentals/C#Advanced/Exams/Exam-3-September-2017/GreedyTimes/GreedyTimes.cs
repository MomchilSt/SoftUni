using System;
using System.Collections.Generic;
using System.Linq;

class GreedyTimes
{
    static void Main()
    {
        var bag = new Dictionary<string, Dictionary<string, long>>();
        bag.Add("Gold", new Dictionary<string, long>());
        bag.Add("Gem", new Dictionary<string, long>());
        bag.Add("Cash", new Dictionary<string, long>());

        long maxCapacity = long.Parse(Console.ReadLine());

        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < input.Length; i += 2)
        {
            string currentItem = input[i].ToLower();
            long quantity = long.Parse(input[i + 1]);

            if (maxCapacity >= quantity)
            {
                if (currentItem.EndsWith("gem") && bag["Gem"].ContainsKey(currentItem) == false && currentItem.Length >= 4)
                {
                    bag["Gem"].Add(currentItem, 0);
                }
                else if (currentItem.Length == 3 && bag["Cash"].ContainsKey(currentItem) == false)
                {
                    bag["Cash"].Add(currentItem, 0);
                }
                else if (currentItem == "gold" && bag["Gold"].ContainsKey(currentItem) == false)
                {
                    bag["Gold"].Add("gold", 0);
                }
                // проверки на всяка стойност по условие
                // ТОДО: проверка за големината на чантата


                if (currentItem.Length >= 4 && currentItem.EndsWith("gem") && quantity + bag["Gem"].Values.Sum() <= bag["Gold"].Values.Sum())
                {
                    bag["Gem"][currentItem] += quantity;
                    maxCapacity -= quantity;

                    continue;
                }
                else if (currentItem.Length == 3 && quantity + bag["Cash"].Values.Sum() <= bag["Gem"].Values.Sum())
                {
                    bag["Cash"][currentItem] += quantity;
                    maxCapacity -= quantity;
                    continue;
                }
                else if (currentItem == "gold")
                {
                    bag["Gold"]["gold"] += quantity;
                    maxCapacity -= quantity;
                }
            }
        }

        foreach (var currency in bag.OrderByDescending(x => x.Value.Values.Sum()))
        {
            if (currency.Value.Values.Sum() == 0)
            {
                continue;
            }

            Console.WriteLine($"<{currency.Key}> ${currency.Value.Values.Sum()}");

            foreach (var item in currency.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
            {
                if (item.Value == 0)
                {
                    continue;
                }

                string result = string.Empty;

                if (currency.Key == "Cash")
                {
                    string currItem = item.Key;
                    result = currItem.ToUpper();
                }
                else
                {
                    string currItem = item.Key;
                    result = currItem[0].ToString().ToUpper() + currItem.Substring(1, currItem.Length - 1);
                }

                Console.WriteLine($"##{result} - {item.Value}");
            }
        }
    }
}
