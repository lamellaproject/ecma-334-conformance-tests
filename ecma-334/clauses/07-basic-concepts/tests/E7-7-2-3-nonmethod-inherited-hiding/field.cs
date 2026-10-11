/*
Rules: E7-7-2-3-nonmethod-inherited-hiding; E7-7-2-3-inheritance-hiding-definition
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new int Read = 29;
Into: public new int Renamed = 29;
*/
using System;
class Root { public int Read() { return 17; } public int Read(int value) { return 23; } }
class Branch : Root { public new int Read = 29; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch value = new Branch();
        Check(value.Read == 29, "new-field-visible-in-place-of-base-methods");
        Check(((Root)value).Read() == 17, "hidden-base-method-through-base-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
