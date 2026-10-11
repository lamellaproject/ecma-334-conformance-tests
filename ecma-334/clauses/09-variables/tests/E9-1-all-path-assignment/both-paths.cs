/*
Rules: E9-1-all-path-assignment; E9-1-initial-state-categories; E9-4-1-definite-assignment-proof; E9-4-4-1-analysis-equivalence; E9-4-4-1-analysis-function-bodies; E9-4-4-1-statement-entry-state; E9-4-4-1-statement-end-state; E9-4-4-1-control-arc-state; E9-4-4-1-definitely-assigned-state; E9-4-4-2-statement-entry-join; E9-4-4-2-statement-end-join
Authority: ECMA-334 7th ed 9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: else cell = 41;
Into: else { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool choose)
    {
        int cell;
        if (choose) cell = 17;
        else cell = 41;
        return cell;
    }
    static void Main()
    {
        Check(Read(true) == 17, "true-path-assignment");
        Check(Read(false) == 41, "false-path-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
