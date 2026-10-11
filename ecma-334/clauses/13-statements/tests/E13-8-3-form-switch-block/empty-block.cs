/*
Rules: E13-8-3-form-switch-block; E13-8-3-switch-expression-evaluation; E13-8-3-unmatched-switch-exit
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: switch (Select()) { }
Into: { }
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Select() { calls++; return 23; }
    static void Main()
    {
        switch (Select()) { }
        Check(calls == 1, "empty-switch-evaluates-expression-and-exits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
