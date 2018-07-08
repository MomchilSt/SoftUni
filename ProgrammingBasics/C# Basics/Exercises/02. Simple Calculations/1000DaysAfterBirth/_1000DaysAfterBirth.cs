using System;
using System.Globalization;

class _1000DaysAfterBirth
{
    static void Main()
    {
        var n = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

        var adding = n.AddDays(999);
        var tostr = adding.ToString("dd-MM-yyyy");
        Console.WriteLine(tostr);
        //01-01-2012
    }
}
