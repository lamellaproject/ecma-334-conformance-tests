/*
Rules: E9-4-4-34-other-pattern-exit-state; E9-4-4-34-pattern-variable-true-state
Authority: ECMA-334 7th ed 9.4.4.34
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (object)(cell = 81)
Into: (object)81
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        bool matched = false;
        if ((object)(cell = 81) is int number)
        {
            matched = true;
            Check(number == 81, "pattern-variable-assigned-after-true");
        }
        Check(cell == 81 && matched, "operand-assignment-preserved-for-other-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
