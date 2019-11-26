using System;
using System.Collections.Generic;
using System.Linq;

class ProductShop
{
    static void Main()
    {
        var shopDict = new Dictionary<string, Dictionary<string, double>>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Revision")
            {
                break;
            }

            string[] tokens = input.Split(", ");
            string shop = tokens[0];
            string product = tokens[1];
            double price = double.Parse(tokens[2]);

            if (shopDict.ContainsKey(shop) == false)
            {
                shopDict.Add(shop, new Dictionary<string, double>());
            }
            else if (shopDict.ContainsKey(shop))
            {
                shopDict[shop].Add(product, price);
                continue;
            }

            shopDict[shop].Add(product, price);
        }

        foreach (var shop in shopDict.OrderBy(x=> x.Key))
        {
            Console.WriteLine(shop.Key + "->");

            foreach (var product in shop.Value)
            {
                Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
            }
        }
    }
}
