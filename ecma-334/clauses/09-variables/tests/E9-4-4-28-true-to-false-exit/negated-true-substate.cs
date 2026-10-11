/*
Rules: E9-4-4-28-true-to-false-exit
Authority: ECMA-334 7th ed 9.4.4.28
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: !(gate && (cell = 42) > 0)
Into: (gate && (cell = 42) > 0)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool gate)
    {
        int cell;
        if (!(gate && (cell = 42) > 0)) return -1;
        else return cell;
    }
    static void Main()
    {
        Check(Read(true) == 42, "negation-makes-true-substate-false");
        Check(Read(false) == -1, "negated-true-path-does-not-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
