/*
Rules: E9-4-4-26-second-entry
Authority: ECMA-334 7th ed 9.4.4.26
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: gate && (cell = 43) > 0
Into: gate || (cell = 43) > 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Read(bool gate)
    {
        int cell;
        return (gate && (cell = 43) > 0) && cell == 43;
    }
    static void Main()
    {
        Check(Read(true), "and-second-reads-true-substate");
        Check(!Read(false), "and-second-skipped-when-not-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
