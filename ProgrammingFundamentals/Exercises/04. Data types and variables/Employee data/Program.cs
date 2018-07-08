using System;

class Program
{
    static void Main()
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string gender = Console.ReadLine();
        long personalID = long.Parse(Console.ReadLine());
        int uniqueNum = int.Parse(Console.ReadLine());

        Console.WriteLine($"First name: {firstName}");
        Console.WriteLine($"Last name: {lastName}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Gender: {gender}");
        Console.WriteLine($"Personal ID: {personalID}");
        Console.WriteLine($"Unique Employee number: {uniqueNum}");
    }
}
