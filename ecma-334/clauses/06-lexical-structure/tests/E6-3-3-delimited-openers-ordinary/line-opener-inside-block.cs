/*
Rules: E6-3-3-delimited-openers-ordinary
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: /* // amount = 88;
Into: // amount = 88;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int amount = 7;
        /* // amount = 88; */ amount = 19;
        Check(amount == 19, "line-opener-does-not-hide-block-terminator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
