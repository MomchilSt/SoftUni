using System;
using System.Numerics;

    class Program
    {
        static void Main()
        {
            byte centuries = byte.Parse(Console.ReadLine());

            ushort years = (ushort)(centuries * 100);
            int days = (int)(years * 365.2422);
            int hours = (int)days * 24;
            long mins = hours * 60;
            long seconds = mins * 60;
            ulong miliSec = (ulong)seconds * 1000;
        BigInteger microSec = (BigInteger)miliSec * 1000;
        BigInteger nanoSec = microSec * 1000;

        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {mins} minutes = {seconds} seconds = {miliSec} milliseconds = {microSec} microseconds = {nanoSec} nanoseconds");
    
    }
   }
