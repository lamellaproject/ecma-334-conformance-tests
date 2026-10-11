/*
Rules: E9-4-4-28-false-to-true-exit
Authority: ECMA-334 7th ed 9.4.4.28
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: !(gate || (cell = 36) < 0)
Into: (gate || (cell = 36) < 0)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool gate)
    {
        int cell;
        if (!(gate || (cell = 36) < 0)) return cell;
        return -1;
    }
    static void Main()
    {
        Check(Read(false) == 36, "negation-makes-false-substate-true");
        Check(Read(true) == -1, "negated-false-path-does-not-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
