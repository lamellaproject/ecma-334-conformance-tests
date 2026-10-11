/*
Rules: E20-4-ref-identity
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: Change converted=Bridge.Save;
Into: Change converted=default(Change);
Csc: CS0123
*/
using System;

delegate void Change(ref string s); static class Bridge {public static void Save(ref object s){} }
class Program
{
    static void Main()
    {
        Change converted=Bridge.Save;
    }
}
