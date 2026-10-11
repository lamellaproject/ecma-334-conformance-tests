/*
Rules: E9-4-4-15-other-exit-assignment-preserved
Authority: ECMA-334 7th ed 9.4.4.15
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: cell = 94;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        try { cell = 94; goto Done; }
        finally { }
        Done: Check(cell == 94, "goto-state-preserved-through-empty-finally");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
