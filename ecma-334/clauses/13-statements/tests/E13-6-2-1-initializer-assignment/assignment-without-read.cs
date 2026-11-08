/*
Rules: E13-6-2-1-initializer-assignment
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Diagnostic: none
Mutate: int slot = (slot = Next());
Into: int slot = slot + Next();
*/
// ECMA-334 7th ed 7.7.1, p. 59 (PDF p. 87), permits this assignment without a read.
// Definite assignment under 13.6.2.1, p. 303 (PDF p. 331), still forbids an unassigned read.
using System;
class Program
{
    static int calls, checks, failures;
    static int Next() { calls++; return calls * 37; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int slot = (slot = Next());
        Check(slot == 37 && calls == 1, "assignment-without-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
