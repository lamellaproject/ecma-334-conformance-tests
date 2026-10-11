/*
Rules: E23-9-other-stackalloc-semantics
Authority: ECMA-334 7th ed 23.9
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: { Observe("a", 17), Observe("b", 29) }
Into: { Observe("b", 29), Observe("a", 17) }
*/
using System;
class Program
{
    static int checks, failures, calls;
    static string order = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static short Observe(string id, short value) { calls++; order += id; return value; }
    static unsafe void Main()
    {
        // 23.9, p. 568: "to be beginning" appears to be a typo; follow the intent, the block's beginning.
        short* memory = stackalloc short[2] { Observe("a", 17), Observe("b", 29) };
        Check(calls == 2, "each-stackalloc-initializer-evaluated-once");
        Check(order == "ab", "stackalloc-initializers-evaluated-in-order");
        Check(memory[0] == 17, "first-initializer-stored-at-zero");
        Check(memory[1] == 29, "second-initializer-stored-at-one");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
