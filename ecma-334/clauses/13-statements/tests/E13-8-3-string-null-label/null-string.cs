/*
Rules: E13-8-3-string-null-label
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: case null:
Into: case "present":
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string selector = null;
        int observed = 0;
        switch (selector) { case null: observed = 4; break; default: observed = 9; break; }
        Check(observed == 4, "string-null-case-selected");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
