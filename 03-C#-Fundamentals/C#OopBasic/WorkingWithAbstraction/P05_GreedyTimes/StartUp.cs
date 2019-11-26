using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class StartUp
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] inputArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long money = 0;

            for (int i = 0; i < inputArgs.Length; i += 2)
            {
                string name = inputArgs[i];
                long currencyCount = long.Parse(inputArgs[i + 1]);

                string currentCurrency = string.Empty;

                if (name.Length == 3)
                {
                    currentCurrency = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    currentCurrency = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    currentCurrency = "Gold";
                }

                if (currentCurrency == "")
                {
                    continue;
                }
                else if (capacity < bag.Values.Select(x => x.Values.Sum()).Sum() + currencyCount)
                {
                    continue;
                }

                switch (currentCurrency)
                {
                    case "Gem":
                        if (!bag.ContainsKey(currentCurrency))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (currencyCount > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[currentCurrency].Values.Sum() + currencyCount > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;

                    case "Cash":
                        if (!bag.ContainsKey(currentCurrency))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (currencyCount > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[currentCurrency].Values.Sum() + currencyCount > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(currentCurrency))
                {
                    bag[currentCurrency] = new Dictionary<string, long>();
                }

                if (!bag[currentCurrency].ContainsKey(name))
                {
                    bag[currentCurrency][name] = 0;
                }

                bag[currentCurrency][name] += currencyCount;
                if (currentCurrency == "Gold")
                {
                    gold += currencyCount;
                }
                else if (currentCurrency == "Gem")
                {
                    gems += currencyCount;
                }
                else if (currentCurrency == "Cash")
                {
                    money += currencyCount;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}