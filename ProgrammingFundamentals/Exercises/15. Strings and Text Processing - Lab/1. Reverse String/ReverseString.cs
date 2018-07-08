using System;
using System.Linq;

class ReverseString
{
    static void Main()
    {
        string str = Console.ReadLine();

        str = new string(str.Reverse().ToArray());

        Console.WriteLine(str);
    }
}
