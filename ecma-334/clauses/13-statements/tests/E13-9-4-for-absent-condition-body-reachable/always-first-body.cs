/*
Rules: E13-9-4-for-absent-condition-body-reachable
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: for (; ; )
Into: for (; false; )
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read() { for (; ; ) { return 3; } }
    static void Main()
    {
        Check(Read() == 3, "absent-condition-enters-body-and-needs-no-later-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
