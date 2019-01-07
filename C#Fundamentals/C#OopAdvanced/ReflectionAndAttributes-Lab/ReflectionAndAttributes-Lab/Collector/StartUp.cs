using System;

public class StartUp
{
    public static void Main()
    {
        Spy spy = new Spy();
        string className = typeof(Hacker).Name;
        string result = spy.CollectGettersAndSetters(className);
        Console.WriteLine(result);
    }
}
