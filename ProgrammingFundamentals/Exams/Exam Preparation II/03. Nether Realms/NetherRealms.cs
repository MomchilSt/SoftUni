using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Demon
{
    public string Name { get; set; }
    public decimal Health { get; set; }
    public decimal Damage { get; set; }
}

class NetherRealms
{
    static void Main()
    {
        string[] demons = Console.ReadLine()
            .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        List<Demon> book = new List<Demon>();

        for (int i = 0; i < demons.Length; i++)
        {
            Demon demon = new Demon();

            demon.Name = demons[i];
            demon.Health = GetDemonHealth(demons[i]);
            demon.Damage = GetDemonDamage(demons[i]);

            book.Add(demon);
        }

        book = book.OrderBy(x => x.Name).ToList();

        foreach (Demon dem in book)
        {
            Console.WriteLine($"{dem.Name} - {dem.Health} health, {dem.Damage:F2} damage");
        }
    }

    private static decimal GetDemonHealth(string name)
    {
        decimal health = 0m;

        foreach (char symb in name)
        {
            bool isMatch = Regex.IsMatch(symb.ToString(), @"[^0-9\+\-\*\/\.]");

            if (isMatch)
            {
                health += symb;
            }
        }

        return health;
    }

    private static decimal GetDemonDamage(string name)
    {
        decimal[] nums = Regex.Matches(name, @"[\-\+]?\d+(\.\d+)?")
            .Cast<Match>()
            .Select(x => x.Value)
            .Select(x => decimal.Parse(x))
            .ToArray();

        decimal damage = nums.Sum();

        foreach (char symb in name)
        {
            switch (symb)
            {
                case '*':
                    damage *= 2.0m;
                    break;
                case '/':
                    damage /= 2.0m;
                    break;
            }
        }

        return damage;
    }
}
