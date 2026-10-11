/*
Rules: E13-2-unreachable-warning
Authority: ECMA-334 7th ed 13.2
Version: 7.3
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: if (false) mark = 6;
Into: if (true) mark = 6;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int mark = 0;
        if (false) mark = 6;
        Check(mark == 0, "unreachable-branch-is-skipped-and-warned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
