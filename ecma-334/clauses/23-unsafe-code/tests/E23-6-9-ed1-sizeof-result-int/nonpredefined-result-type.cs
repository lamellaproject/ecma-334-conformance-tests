/*
Rules: E23-6-9-ed1-sizeof-result-int
Authority: ECMA-334 1st ed 25.5.8
Version: ISO-1
Expected: run
Stdout: OK 1
Mutate: Choose(sizeof(Slot))
Into: Choose((long)sizeof(Slot))
*/
// ECMA-334 1st ed 25.5.8, p. 332 (PDF p. 346), lines 18-23. The sizeof result has type int
// for every permitted unmanaged operand, including a nonpredefined struct.
using System;
struct Slot { }
unsafe class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    static string Choose(int value) { return "INT"; }
    static string Choose(long value) { return "LONG"; }
    static int Main()
    {
        Check(Choose(sizeof(Slot)) == "INT", "int-result-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
