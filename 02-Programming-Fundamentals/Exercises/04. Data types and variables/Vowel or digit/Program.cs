using System;

class Program
{
    static void Main()
    {
        char input = char.Parse(Console.ReadLine());

        if (input >= '0' && input <= '9')
        {
            Console.WriteLine("digit");
        }
        else if (input == 'a' || input == 'A' || 
                 input == 'i' || input == 'I' ||
                 input == 'o' || input == 'O' ||
                 input == 'u' || input == 'U' ||
                 input == 'e' || input == 'E')
        {
            Console.WriteLine("vowel");
        }
        else
        {
            Console.WriteLine("other");
        }
    }
}
