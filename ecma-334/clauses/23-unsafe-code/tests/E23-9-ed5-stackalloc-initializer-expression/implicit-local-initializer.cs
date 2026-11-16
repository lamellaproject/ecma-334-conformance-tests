/*
Rules: E23-9-ed5-stackalloc-initializer-expression
Authority: ECMA-334 5th ed 13.6.2
Version: 5
Expected: reject
Version-Witness: version-witnesses/E23-9-ed5-stackalloc-initializer-expression/implicit-local-initializer.cs.part
Mutate: var memory = stackalloc int[Count()];
Into: int* memory = stackalloc int[Count()];
*/
// ECMA-334 5th ed 13.6.2, p. 223 (PDF p. 245), and 23.9, p. 427 (PDF p. 449).
// An implicitly typed local requires an expression; stackalloc-initializer is a separate production.
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Count() { calls++; return 2; }
    static unsafe void Main()
    {
        var memory = stackalloc int[Count()];
        Check(calls == 1, "count-evaluated-once");
        memory[0] = 73;
        Check(*memory == 73, "explicit-pointer-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
