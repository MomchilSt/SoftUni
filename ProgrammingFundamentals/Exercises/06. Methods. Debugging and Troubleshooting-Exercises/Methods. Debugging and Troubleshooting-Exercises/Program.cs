using System;

class P1HelloName
{
    static void Main()
    {
        PrintName();
    }

    static void PrintName()
    {
        string name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}!");
    }
}
