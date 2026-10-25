/*
Rules: E12-8-9-4-ed1-null-delegate-before-arguments
Authority: ECMA-334 1st ed 14.5.5.2
Version: ISO-1
Expected: run
Stdout: OK 2
Diagnostic: none
Version-Witness: tests/E12-8-9-4-ed1-null-delegate-before-arguments/null-delegate-argument-order.witness.cs.part
Mutate: Delivery target = null;
Into: Delivery target = new Delivery(Receive);
*/
// ECMA-334 1st ed 14.5.5.2, p. 143 (PDF p. 157), lines 32-37 checks null before invoking
// the function member.
using System;
delegate void Delivery(int item);
class Entry
{
    static int checks;
    static int failures;
    static int calls;
    static int Fetch() { calls++; return 57; }
    static void Receive(int item) { }
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    public static int Main()
    {
        Delivery target = null;
        bool caught = false;
        try { target(Fetch()); }
        catch (NullReferenceException) { caught = true; }
        Check(caught, "null-delegate-exception");
        Check(calls == 0, "argument-not-evaluated");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
