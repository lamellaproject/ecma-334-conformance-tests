/*
Rules: E15-2-5-base-dependent
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : Root
Into: 
*/
using System;
class Root { public int Number = 223; }
class Leaf : Root { }
class Program
{
    static int Read<S,T>(S value) where S : T where T : Root { return value.Number; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read<Leaf,Root>(new Leaf()) == 223, "dependent-parameter-contributes-effective-base-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
