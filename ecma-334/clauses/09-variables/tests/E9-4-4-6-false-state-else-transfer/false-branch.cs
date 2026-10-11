/*
Rules: E9-4-4-6-false-state-else-transfer; E9-4-4-1-assigned-after-false-state; E9-4-4-27-false-second-exit
Authority: ECMA-334 7th ed 9.4.4.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: gate || (cell = 36) < 0
Into: gate && (cell = 36) < 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool gate)
    {
        int cell;
        if (gate || (cell = 36) < 0) return -1;
        else return cell;
    }
    static void Main()
    {
        Check(Read(false) == 36, "false-substate-assigned");
        Check(Read(true) == -1, "true-substate-does-not-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
