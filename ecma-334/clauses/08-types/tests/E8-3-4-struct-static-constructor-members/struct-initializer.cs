/*
Rules: E8-3-4-struct-static-constructor-members
Authority: ECMA-334 7th ed 8.3.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Ready = 33;
Into: Ready = 34;
*/
using System;
struct Sample { public static int Ready; static Sample() { Ready = 33; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Sample.Ready == 33, "struct-static-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
