using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] characters = Console.ReadLine().Split().ToArray();
        Array.Reverse(characters);
        Console.WriteLine(string.Join(" ", characters));
    }
}
