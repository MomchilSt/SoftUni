using System;

class Program
{
    static void Main()
    {
        int counter = 0;
        try
        {
            while (true)
            {
                int integer = int.Parse(Console.ReadLine());
                counter++;
            }
        }
        catch (Exception)
        {

            Console.WriteLine(counter);
        }
    }
}
