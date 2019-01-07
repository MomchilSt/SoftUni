using System;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        Spy spy = new Spy();
        string className = typeof(Hacker).FullName;
        string result = spy.StealFieldInfo(className, "username", "password");
        Console.WriteLine(result);
    }
}