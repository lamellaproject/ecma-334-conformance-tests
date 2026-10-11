/*
Rules: E23-5-2-array-object-element-access
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: object result = Observe().GetValue(0);
Into: object result = null;
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int calls;
    static Array items;
    static Array Observe() { calls++; return items; }
    static void Main()
    {
        int value = 13;
        items = new int*[] { &value };
        bool completed = false;
        // This access may return normally or throw; the rule does not fix a value or exception type.
        try { object result = Observe().GetValue(0); completed = true; }
        catch (Exception) { completed = true; }
        Check(completed, "object-access-completes-or-throws");
        Check(calls == 1, "object-access-executed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
