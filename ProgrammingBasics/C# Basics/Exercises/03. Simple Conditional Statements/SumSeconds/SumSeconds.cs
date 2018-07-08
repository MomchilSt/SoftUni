using System;

class SumSeconds
{
    static void Main()
    {
        byte racer1Secs = byte.Parse(Console.ReadLine());
        byte racer2Secs = byte.Parse(Console.ReadLine());
        byte racer3Secs = byte.Parse(Console.ReadLine());

        var sum = (racer1Secs + racer2Secs + racer3Secs);
        var mins = sum / 60;
        var secs = sum % 60;

        if (secs <= 9)
        {
            Console.WriteLine(mins + ":0" + secs);
        }
        else
        {
            Console.WriteLine(mins + ":" + secs);
        }
        //Console.WriteLine("{0}:{1:00}", mins, secs);
    }
}
