using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        decimal sum = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end of shift")
            {
                break;
            }

            var nameProductQuantity = new Regex(@"%([A-Z]{1}[a-z]+)%[^%\|$\.]*?<(\w+)>[^%\|$\.]*?\|(\d+)\|[^%\|$\.]*?([0-9.0-9]+)\$");
            //var pricePatt = new Regex(@"\|?[-+]?([0-9]*\.?[0-9]*)\$");

            var matchNameToQuantity = nameProductQuantity.Match(input);
            //var matchPrice = pricePatt.Match(input);

            if (matchNameToQuantity.Success)
            {
                string name = matchNameToQuantity.Groups[1].Value;
                string product = matchNameToQuantity.Groups[2].Value;
                int quantity = int.Parse(matchNameToQuantity.Groups[3].Value);
                decimal price = decimal.Parse(matchNameToQuantity.Groups[4].Value);

                Console.WriteLine($"{name}: {product} - {(price*quantity):f2}");
                sum += quantity * price;
            }

        }

        Console.WriteLine($"Total income: {sum:f2}");
    }
}
//@"\|?([-+]?[0-9]*\.?[0-9]*)\$"
//@"\|?([-+]?[0-9]*\.?[0-9]*)\$