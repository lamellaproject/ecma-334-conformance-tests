/*
Rules: E10-1-representation; E10-1-type-wide; E10-2-3-int; E10-2-3-exact
Authority: ECMA-334 7th ed 10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: long result = input;
Into: long result = 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int input = -197;
        long result = input;
        Check(result == -197L, "implicit-long/value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
