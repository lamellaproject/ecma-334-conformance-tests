/*
Rules: E9-4-4-26-assigned-first-exit; E9-4-4-26-first-entry; E9-4-4-26-second-entry; E9-4-4-27-assigned-first-exit; E9-4-4-27-first-entry
Authority: ECMA-334 7th ed 9.4.4.26
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (left = 15) > 0
Into: true
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int left;
        bool and = (left = 15) > 0 && left == 15;
        Check(and && left == 15, "and-first-assigns-second-and-exit");
        int right;
        bool or = (right = 19) < 0 || right == 19;
        Check(or && right == 19, "or-first-assigns-second-and-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
