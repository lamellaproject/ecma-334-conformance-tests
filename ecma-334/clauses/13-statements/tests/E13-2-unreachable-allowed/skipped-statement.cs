/*
Rules: E13-2-unreachable-allowed; E13-2-unreachable-definition; E13-3-2-list-label-reachable
Authority: ECMA-334 7th ed 13.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: goto finish;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int mark = 0;
        goto finish;
        mark = 3;
        finish: Check(mark == 0, "goto-skips-unreachable-statement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
