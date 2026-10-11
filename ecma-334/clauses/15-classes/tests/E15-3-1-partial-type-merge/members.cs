/*
Rules: E15-3-1-partial-type-merge; E15-3-1-partial-member-union; E15-3-1-partial-member-scope; E15-3-1-partial-private-access
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: partial class Gauge { private int Add() { return secret + 2; } public int Next() { return Read() + 1; } }
Into: partial class Other { private int Add() { return 2; } public int Next() { return 3; } }
*/
using System;
partial class Gauge { private int secret = 251; public int Read() { return Add(); } }
partial class Gauge { private int Add() { return secret + 2; } public int Next() { return Read() + 1; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge value = new Gauge();
        Check(value.Read() == 253, "member-scope-and-private-access-across-parts");
        Check(value.Next() == 254, "union-of-part-members-in-single-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
