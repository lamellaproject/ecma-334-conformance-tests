/*
Rules: E9-4-4-30-true-operand-entry; E9-4-4-30-false-operand-entry
Authority: ECMA-334 7th ed 9.4.4.30
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: gate && (cell = 13) > 0
Into: gate || (cell = 13) > 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int WhenTrue(bool gate) { int cell; return gate && (cell = 13) > 0 ? cell : -1; }
    static int WhenFalse(bool gate) { int cell; return gate || (cell = 24) < 0 ? -1 : cell; }
    static void Main()
    {
        Check(WhenTrue(true) == 13, "true-substate-in-true-operand");
        Check(WhenTrue(false) == -1, "unassigned-false-path-does-not-read");
        Check(WhenFalse(false) == 24, "false-substate-in-false-operand");
        Check(WhenFalse(true) == -1, "unassigned-true-path-does-not-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
