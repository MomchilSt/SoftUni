using System;

namespace RandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var rl = new RandomList();
            Console.WriteLine(rl.RandomInteger());
        }
    }
}
