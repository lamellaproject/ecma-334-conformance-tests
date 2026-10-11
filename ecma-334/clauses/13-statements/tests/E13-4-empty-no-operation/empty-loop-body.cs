/*
Rules: E13-4-empty-no-operation; E13-4-form-empty; E13-4-empty-control; E13-4-empty-end-reachable; E13-1-embedded-empty
Authority: ECMA-334 7th ed 13.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: while (hits++ < 2) ;
Into: while (hits++ < 2) hits += 2;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int hits = 0;
        while (hits++ < 2) ;
        Check(hits == 3, "empty-body-has-no-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
