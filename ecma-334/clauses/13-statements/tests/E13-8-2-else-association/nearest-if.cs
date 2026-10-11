/*
Rules: E13-8-2-else-association; E13-1-embedded-selection
Authority: ECMA-334 7th ed 13.8.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: if (Gate()) if (false) mark = 1; else mark = 2;
Into: if (Gate()) { if (false) mark = 1; } else mark = 2;
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Gate() { calls++; return true; }
    static void Main()
    {
        int mark = 0;
        if (Gate()) if (false) mark = 1; else mark = 2;
        Check(mark == 2, "else-belongs-to-inner-if");
        Check(calls == 1, "outer-condition-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
