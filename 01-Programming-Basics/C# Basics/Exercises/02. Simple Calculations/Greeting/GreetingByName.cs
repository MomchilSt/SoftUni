using System;

class GreetingByName
{
    static void Main()
    {
        Console.WriteLine("What's your Name:");
        var name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!", name);
    }
}
