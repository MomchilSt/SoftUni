﻿using System;

public class StartUp
{
    public static void Main()
    {
        Spy spy = new Spy();
        string className = typeof(Hacker).FullName;
        string result = spy.RevealPrivateMethods(className);
        Console.WriteLine(result);
    }
}
