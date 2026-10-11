/*
Rules: E9-4-4-6-true-state-then-transfer; E9-4-4-1-boolean-conditional-substates; E9-4-4-1-assigned-after-true-state; E9-4-4-26-true-second-exit
Authority: ECMA-334 7th ed 9.4.4.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: gate && (cell = 42) > 0
Into: gate || (cell = 42) > 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool gate)
    {
        int cell;
        if (gate && (cell = 42) > 0) return cell;
        return -1;
    }
    static void Main()
    {
        Check(Read(true) == 42, "true-substate-assigned");
        Check(Read(false) == -1, "false-substate-does-not-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
