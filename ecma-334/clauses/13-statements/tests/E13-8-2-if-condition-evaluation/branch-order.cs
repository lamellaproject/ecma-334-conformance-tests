/*
Rules: E13-8-2-if-condition-evaluation; E13-8-2-form-if; E13-8-2-form-if-else; E13-8-2-if-true-branch; E13-8-2-if-first-branch-exit; E13-8-2-if-false-else-branch; E13-8-2-if-second-branch-exit; E13-8-2-if-false-no-else; E13-8-1-selection-value; E13-8-1-form-if-selection
Authority: ECMA-334 7th ed 13.8.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: if (Condition(true))
Into: if (Condition(false))
*/
using System;
class Program
{
    static int checks, failures;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Condition(bool result) { trace += "C"; return result; }
    static void Main()
    {
        if (Condition(true)) trace += "T"; else trace += "F";
        trace += "E";
        Check(trace == "CTE", "condition-then-true-branch-then-end");
        trace = "";
        if (Condition(false)) trace += "X"; else trace += "F";
        trace += "E";
        Check(trace == "CFE", "condition-then-else-branch-then-end");
        trace = "";
        if (Condition(false)) trace += "X";
        trace += "E";
        Check(trace == "CE", "false-without-else-reaches-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
