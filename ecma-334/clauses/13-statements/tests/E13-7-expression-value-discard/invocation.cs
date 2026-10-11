/*
Rules: E13-7-expression-value-discard; E13-7-expression-evaluation; E13-1-embedded-expression; E13-7-form-expression-statement; E13-7-form-invocation; E13-7-expression-control
Authority: ECMA-334 7th ed 13.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Fetch();
Into: ;
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Fetch() { calls++; return 17; }
    static void Main()
    {
        if (true) Fetch();
        Check(calls == 1, "discarded-value-keeps-side-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
