/*
Rules: E9-4-4-28-assigned-operand-exit; E9-4-4-28-operand-entry
Authority: ECMA-334 7th ed 9.4.4.28
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (cell = 13) > 0
Into: true
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        bool result = !((cell = 13) > 0);
        Check(!result && cell == 13, "negation-preserves-operand-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
