/*
Rules: E12-6-3-ed3-consistent-type-inference
Authority: ECMA-334 3rd ed 25.6.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-3-ed3-consistent-type-inference/delegate-parameter-arguments.cs.part
Mutate: Wire action = Pass;
Into: Wire action = Pass<object>;
*/
// ECMA-334 3rd ed 25.6.4, p. 398 (PDF p. 418).
using System;
delegate void Wire(string first, object second);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int calls;
    static void Pass<T>(T first, T second) { calls++; }
    static int Main()
    {
        Wire action = Pass;
        action("ore", new object());
        Check(calls == 1, "delegate-inference");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
