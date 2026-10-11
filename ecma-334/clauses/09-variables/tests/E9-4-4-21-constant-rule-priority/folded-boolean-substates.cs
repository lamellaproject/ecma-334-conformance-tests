/*
Rules: E9-4-4-21-constant-rule-priority; E9-4-4-21-constant-true-false-state; E9-4-4-21-constant-false-true-state
Authority: ECMA-334 7th ed 9.4.4.21
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: const int limit = 6;
Into: int limit = 6;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const int limit = 6;
        int trueCell, falseCell;
        // Folding the relational expressions takes precedence over ordinary embedded-expression transfer.
        bool trueResult = (limit > 2) || trueCell > 0;
        bool falseResult = (limit < 2) && falseCell > 0;
        Check(trueResult, "constant-true-has-assigned-false-substate");
        Check(!falseResult, "constant-false-has-assigned-true-substate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
