/*
Rules: E12-6-4-1-dynamic-ambiguous-best
Authority: ECMA-334 7th ed 12.6.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Pick(first, second)
Into: Pick(first, (long)second)
*/
using System;
class Program
{
    static int checks, failures, calls;
    public static void Pick(int x, long y) { calls++; }
    public static void Pick(long x, int y) { calls++; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic first = 3, second = 5;
        bool ambiguous = false;
        try { Pick(first, second); }
        catch (Exception) { ambiguous = true; }
        Check(ambiguous, "no-unique-best-method-causes-runtime-binding-exception");
        Check(calls == 0, "ambiguous-dynamic-call-does-not-enter-either-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
