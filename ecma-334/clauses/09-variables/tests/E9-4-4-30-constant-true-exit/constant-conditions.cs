/*
Rules: E9-4-4-30-constant-true-exit; E9-4-4-30-constant-false-exit
Authority: ECMA-334 7th ed 9.4.4.30
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: true ? (cell = 16) : 0
Into: gate ? (cell = 16) : 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int WhenTrue(bool gate) { int cell; int result = true ? (cell = 16) : 0; return result + cell; }
    static int WhenFalse() { int cell; int result = false ? 0 : (cell = 37); return result + cell; }
    static void Main()
    {
        Check(WhenTrue(true) == 32, "constant-true-uses-true-operand-state");
        Check(WhenFalse() == 74, "constant-false-uses-false-operand-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
