/*
Rules: E9-4-4-9-false-state-end-transfer
Authority: ECMA-334 7th ed 9.4.4.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: gate || (cell = 54) < 0
Into: gate && (cell = 54) < 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool gate)
    {
        int cell;
        do { gate = false; } while (gate || (cell = 54) < 0);
        return cell;
    }
    static void Main()
    {
        Check(Read(true) == 54, "false-condition-assigns-do-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
