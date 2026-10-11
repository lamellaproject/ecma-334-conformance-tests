/*
Rules: E13-9-2-while-break-end-reachable; E13-9-2-while-condition-end-reachable
Authority: ECMA-334 7th ed 13.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: while (true) { break; }
Into: break;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read()
    {
        while (true) { while (true) { break; } return 8; }
    }
    static void Main()
    {
        Check(Read() == 8, "inner-break-does-not-make-outer-end-reachable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
