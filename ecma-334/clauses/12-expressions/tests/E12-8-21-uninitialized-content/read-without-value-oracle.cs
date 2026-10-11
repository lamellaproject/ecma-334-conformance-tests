/*
Rules: E12-8-21-uninitialized-content
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: stackalloc int[1]
Into: stackalloc int[0]
*/
using System;
class Program
{
    static int checks, failures;
    public static int observed;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Span<int> values = stackalloc int[1];
        // Every int bit pattern is allowed; reading an in-range item need only complete.
        observed = values[0];
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
