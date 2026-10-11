/*
Rules: E13-15-yield-contextual-keyword
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int yield = 19;
Into: int other = 19;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }

    static void Main()
    {
        int yield = 19;
        Check(yield + 4 == 23, "yield-is-an-ordinary-identifier");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
