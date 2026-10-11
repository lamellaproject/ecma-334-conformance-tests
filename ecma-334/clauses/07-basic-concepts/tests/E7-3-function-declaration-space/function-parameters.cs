/*
Rules: E7-3-function-declaration-space; E7-3-function-parameter-names; E7-7-1-method-type-parameter-scope
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static T First<T>(T value, params T[] others)
Into: static T First<U>(T value, params T[] others)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static T First<T>(T value, params T[] others) { return others.Length == 0 ? value : others[0]; }
    static void Main()
    {
        Check(First<int>(17) == 17, "fixed-and-type-parameter-names");
        Check(First<int>(17, 23, 29) == 23, "parameter-array-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
