/*
Rules: E10-8-optional
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: reject
Mutate: Action converted=Bridge.Save;
Into: Action converted=default(Action);
Csc: CS0123
*/
using System;

static class Bridge {public static void Save(int n=61){} }
class Program
{
    static void Main()
    {
        Action converted=Bridge.Save;
    }
}
