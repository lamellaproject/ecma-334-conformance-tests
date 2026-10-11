/*
Rules: P10-natural-explicit-return
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: Func<object> f=string () => "basalt";
Into: Func<object> f=default(Func<object>);
*/
using System;


class Program
{
    static void Main()
    {
        Func<object> f=string () => "basalt";
    }
}
