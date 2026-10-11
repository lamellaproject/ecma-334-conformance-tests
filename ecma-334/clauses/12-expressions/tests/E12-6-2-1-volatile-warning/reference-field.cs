/*
Rules: E12-6-2-1-volatile-warning; E12-6-2-1-volatile-treatment
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: Update(ref holder.Value)
Into: Update(ref copy)
*/
using System;
class Box { public volatile int Value = 11; }
class Program
{
    static int checks, failures;
    static void Update(ref int value) { value += 17; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box holder = new Box(); int copy = holder.Value; Update(ref holder.Value);
        // Either volatile or ordinary accesses in Update are permitted; no memory-order result is imposed.
        Check(holder.Value == 28, "volatile-reference-operation-completes");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
