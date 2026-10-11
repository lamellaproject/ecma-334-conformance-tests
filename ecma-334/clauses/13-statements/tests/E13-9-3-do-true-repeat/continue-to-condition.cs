/*
Rules: E13-9-3-do-true-repeat; E13-9-3-do-condition-evaluation; E13-9-3-do-continue-permitted
Authority: ECMA-334 7th ed 13.9.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: continue;
Into: ;
*/
using System;
class Program
{
    static int checks, failures, conditions;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Gate() { trace += "C"; conditions++; return conditions < 2; }
    static void Main()
    {
        do { trace += "B"; continue; trace += "X"; } while (Gate());
        trace += "E";
        Check(trace == "BCBCE", "continue-skips-tail-evaluates-condition-and-repeats");
        Check(conditions == 2, "final-false-do-condition-evaluated");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
