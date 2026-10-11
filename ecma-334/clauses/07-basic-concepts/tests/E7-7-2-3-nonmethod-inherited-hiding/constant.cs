/*
Rules: E7-7-2-3-nonmethod-inherited-hiding; E7-7-2-3-inheritance-hiding-definition
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new const int Read = 19;
Into: public new const int Renamed = 19;
*/
using System;
class Root { public int Read() { return 17; } public int Read(int value) { return 23; } }
class Branch : Root { public new const int Read = 19; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Branch.Read == 19, "new-constant-visible-in-place-of-base-methods");
        Check(((Root)new Branch()).Read() == 17, "hidden-base-method-through-base-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
