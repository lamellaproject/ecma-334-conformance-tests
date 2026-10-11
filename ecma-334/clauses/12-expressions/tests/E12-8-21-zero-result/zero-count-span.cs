/*
Rules: E12-8-21-zero-result; E12-8-21-span-length
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: stackalloc int[Zero()]
Into: stackalloc int[Zero() + 1]
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Zero() { calls++; return 0; }
    static void Main()
    {
        Span<int> values = stackalloc int[Zero()];
        Check(calls == 1, "zero-count-expression-evaluated");
        // Accept every internal returned address; only the specified span length is observed.
        Check(values.Length == 0, "zero-items-in-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
