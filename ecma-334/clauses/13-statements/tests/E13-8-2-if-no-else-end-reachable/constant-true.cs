/*
Rules: E13-8-2-if-no-else-end-reachable
Authority: ECMA-334 7th ed 13.8.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: if (true)
Into: if (false)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read() { if (true) return 13; }
    static void Main()
    {
        Check(Read() == 13, "constant-true-no-else-needs-no-later-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
