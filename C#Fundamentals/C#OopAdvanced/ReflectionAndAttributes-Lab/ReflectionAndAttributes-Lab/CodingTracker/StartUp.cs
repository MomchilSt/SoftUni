﻿using System;
using System.Linq;
using System.Reflection;

[SoftUni("Ventsi")]
public class StartUp
{
    [SoftUni("Gosho")]
    public static void Main()
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}