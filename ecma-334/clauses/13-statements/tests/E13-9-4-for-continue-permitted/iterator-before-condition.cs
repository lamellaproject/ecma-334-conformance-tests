/*
Rules: E13-9-4-for-continue-permitted; E13-9-4-for-iterator-order; E13-9-4-for-repeat
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: continue;
Into: ;
*/
using System;
class Program
{
    static int checks, failures, conditions, iterations;
    static string trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Initialize() { trace += "I"; }
    static bool Gate() { trace += "C"; conditions++; return conditions <= 2; }
    static void Step() { trace += "S"; iterations++; }
    static void Main()
    {
        for (Initialize(); Gate(); Step()) { trace += "B"; continue; trace += "X"; }
        trace += "E";
        Check(trace == "ICBSCBSCE", "continue-skips-tail-runs-iterator-then-condition");
        Check(iterations == 2, "iterator-runs-after-each-continue");
        Check(conditions == 3, "condition-ends-continued-loop");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
