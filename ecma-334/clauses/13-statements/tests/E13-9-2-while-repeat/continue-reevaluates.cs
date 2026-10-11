/*
Rules: E13-9-2-while-repeat; E13-1-embedded-iteration; E13-9-1-iteration-repetition; E13-9-1-form-while-iteration; E13-9-2-form-while; E13-9-2-while-condition-evaluation; E13-9-2-while-true-body; E13-9-2-while-false-exit; E13-9-2-while-continue-permitted
Authority: ECMA-334 7th ed 13.9.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: continue;
Into: break;
*/
using System;
class Program
{
    static int checks, failures, conditions;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Gate() { trace += "C"; conditions++; return conditions <= 2; }
    static void Main()
    {
        int bodies = 0;
        if (true) while (Gate()) { trace += "B"; bodies++; continue; }
        Check(bodies == 2, "continue-repeats-body");
        Check(conditions == 3, "condition-includes-final-false");
        Check(trace == "CBCBC", "condition-before-each-body-and-after-continue");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
