/*
Rules: E12-8-5-evaluation; E12-8-5-syntax; E12-8-5-result; E12-8-1-parenthesized-form
Authority: ECMA-334 7th ed 12.8.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (Next())
Into: (8)
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next() { calls++; return 3; }
    static void Main()
    {
        int result = (Next());
        Check(result == 3, "parenthesized-expression-has-contained-result");
        Check(calls == 1, "parenthesized-contained-expression-evaluated-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
