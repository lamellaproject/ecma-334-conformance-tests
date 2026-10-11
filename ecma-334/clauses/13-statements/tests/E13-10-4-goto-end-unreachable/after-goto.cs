/*
Rules: E13-10-4-goto-end-unreachable
Authority: ECMA-334 7th ed 13.10.4
Version: 7.3
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: goto target;
Into: if (value != 0) goto target;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 0;
        goto target;
        value = 9;
        target: Check(value == 0, "statement-after-goto-unreachable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
