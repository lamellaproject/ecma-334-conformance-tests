/*
Rules: E9-4-4-24-omitted-conditional-call-state
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Conditional("SUITE_NEVER_DEFINED")
Into: Conditional("SUITE_ENABLED")
*/
#define SUITE_ENABLED
using System;
class Program
{
    static int checks, failures, called;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    [System.Diagnostics.Conditional("SUITE_NEVER_DEFINED")]
    static void Omit(int value) { called++; }
    static void Main()
    {
        int cell = 5;
        Omit(cell = 33);
        Check(cell == 5 && called == 0, "omitted-conditional-does-not-assign-or-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
