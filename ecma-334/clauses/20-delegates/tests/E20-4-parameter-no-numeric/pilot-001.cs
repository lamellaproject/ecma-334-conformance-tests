/*
Rules: E20-4-parameter-no-numeric
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: Action<int> converted=Bridge.Save;
Into: Action<int> converted=default(Action<int>);
Csc: CS0123
*/
using System;

static class Bridge {public static void Save(long n){} }
class Program
{
    static void Main()
    {
        Action<int> converted=Bridge.Save;
    }
}
