using System;

class ConcatenateData
{
    static void Main()
    {
        Console.WriteLine("Write your first name:");
        var name1 = Console.ReadLine();
        Console.WriteLine("Write your last name:");
        var name2 = Console.ReadLine();
        Console.WriteLine("Write your age:");
        var age = int.Parse(Console.ReadLine());
        Console.WriteLine("Write your town:");
        var town = Console.ReadLine();
        Console.WriteLine("You are {0} {1}, a {2}-years old person from {3}.", name1, name2, age, town);
    }
}
