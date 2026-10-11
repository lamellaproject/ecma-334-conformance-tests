/*
Rules: E15-2-5-base-specific; E15-2-5-effective-base
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where U : Branch
Into: where U : Root
*/
using System;
class Root { }
class Branch : Root { }
class Leaf : Branch { }
class Program
{
    static int Pick(Root value) { return 1; }
    static int Pick(Branch value) { return 2; }
    static int Read<S,T,U>(S value) where S : T, U where T : Root where U : Branch { return Pick(value); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read<Leaf,Root,Branch>(new Leaf()) == 2, "most-encompassed-effective-base-candidate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
