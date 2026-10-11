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
class Root { public class Read { public int Value = 73; } }
class Branch : Root { public new int Read() { return 79; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Branch().Read() == 79, "method-hides-inherited-type");
        Check(new Root.Read().Value == 73, "hidden-type-through-base-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
