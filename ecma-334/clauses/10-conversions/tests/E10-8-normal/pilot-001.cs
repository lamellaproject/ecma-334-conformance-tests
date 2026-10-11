/*
Rules: E10-8-normal
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: reject
Mutate: Action<int,int> converted=Bridge.Save;
Into: Action<int,int> converted=default(Action<int,int>);
Csc: CS0123
*/
using System;

static class Bridge {public static void Save(params int[] numbers){} }
class Program
{
    static void Main()
    {
        Action<int,int> converted=Bridge.Save;
    }
}
