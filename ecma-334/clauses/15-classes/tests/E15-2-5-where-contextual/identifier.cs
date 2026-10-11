/*
Rules: E15-2-5-where-contextual
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int where
Into: int other
*/
using System;
class Program
{
    static int Read(int where) { return where + 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read(109) == 111, "where-used-as-identifier");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
