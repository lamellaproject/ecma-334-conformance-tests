/*
Rules: E23-9-other-local-semantics
Authority: ECMA-334 7th ed 23.9
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: alias = memory;
Into: alias = memory + 1;
*/
using System;
class Program
{
    static int checks, failures, sizeCalls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Size() { sizeCalls++; return 2; }
    static unsafe void Main()
    {
        // 23.9, p. 568: "to be beginning" appears to be a typo; follow the intent, the block's beginning.
        short* memory = stackalloc short[Size()], alias = memory;
        memory[0] = 17;
        memory[1] = 29;
        Check(sizeCalls == 1, "size-initializer-evaluated-once");
        Check(alias == memory, "later-declarator-reads-assigned-earlier-local");
        Check(alias[0] == 17, "alias-reads-first-initialized-slot");
        alias[0] = 41;
        Check(memory[0] == 41, "alias-write-reaches-shared-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
