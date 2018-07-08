using System;

class InvalidNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var range = (n >= 100 && n <= 200 || n == 0);

        if (!range)
        {
            Console.WriteLine("invalid");
        }
    }
}
