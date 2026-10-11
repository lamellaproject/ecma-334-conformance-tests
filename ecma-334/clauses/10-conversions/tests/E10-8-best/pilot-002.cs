/*
Rules: E10-8-best
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: reject
Mutate: Action<int> converted=Bridge.Save;
Into: Action<int> converted=default(Action<int>);
Csc: CS0123
*/
using System;

static class Bridge {public static void Save(string s){} }
class Program
{
    static void Main()
    {
        Action<int> converted=Bridge.Save;
    }
}
