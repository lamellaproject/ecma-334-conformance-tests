/*
Rules: E12-6-4-7-target-one-way-conversion; E12-6-4-5-better-target
Authority: ECMA-334 7th ed 12.6.4.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(null)
Into: Pick((Root)null)
*/
using System;
class Root { }
class Leaf : Root { }
class Program
{
    static int checks, failures;
    static int Pick(Root x) { return 1; }
    static int Pick(Leaf x) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(null) == 2, "untyped-null-prefers-one-way-convertible-leaf-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
