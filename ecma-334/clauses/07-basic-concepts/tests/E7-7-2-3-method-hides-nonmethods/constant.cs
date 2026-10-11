/*
Rules: E7-7-2-3-method-hides-nonmethods
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new int Read()
Into: public new int Renamed()
*/
using System;
class Root { public const int Read = 43; }
class Branch : Root { public new int Read() { return 47; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Branch().Read() == 47, "method-hides-inherited-constant");
        Check(Root.Read == 43, "hidden-constant-through-base-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
