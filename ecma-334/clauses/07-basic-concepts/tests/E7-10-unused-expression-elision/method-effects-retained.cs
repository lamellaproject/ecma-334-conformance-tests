/*
Rules: E7-10-unused-expression-elision; E7-10-side-effect-nonvolatile-write
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int unused = Record() + 3;
Into: int unused = 0 + 3;
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Record() { calls++; return 7; }
    static void Main()
    {
        int unused = Record() + 3;
        int pureUnused = 11 * 13;
        // Pure unused arithmetic may disappear, but the discarded method result does not erase its write.
        Check(calls == 1, "unused-expression-value-retains-needed-method-call-side-effects");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
