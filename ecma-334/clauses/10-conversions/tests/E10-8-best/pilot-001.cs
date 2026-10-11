/*
Rules: E10-8-best
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: reject
Mutate: Action<Both> converted=Bridge.Save;
Into: Action<Both> converted=default(Action<Both>);
Csc: CS0121
*/
using System;


interface IOne {} interface ITwo {} class Both:IOne,ITwo {}
static class Bridge {public static void Save(IOne n){} public static void Save(ITwo n){} }

class Program
{
    static void Main()
    {
        Action<Both> converted=Bridge.Save;
    }
}
