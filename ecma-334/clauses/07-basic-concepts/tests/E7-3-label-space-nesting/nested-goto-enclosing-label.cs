/*
Rules: E7-3-label-space-nesting; E7-3-goto-label-references
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: finished:
Into: renamed:
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 17;
        { goto finished; }
        value = 23;
        finished: Check(value == 17, "nested-block-sees-enclosing-label");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
