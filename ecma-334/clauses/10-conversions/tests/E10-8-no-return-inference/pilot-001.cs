/*
Rules: E10-8-no-return-inference
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: reject
Mutate: Func<int> converted=Bridge.Make;
Into: Func<int> converted=default(Func<int>);
Csc: CS0411
*/
using System;

static class Bridge {public static T Make<T>(){return default(T);} }
class Program
{
    static void Main()
    {
        Func<int> converted=Bridge.Make;
    }
}
