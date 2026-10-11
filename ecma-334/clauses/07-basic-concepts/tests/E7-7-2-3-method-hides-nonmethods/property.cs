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
class Root { public int Read { get { return 61; } } }
class Branch : Root { public new int Read() { return 67; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch value = new Branch();
        Check(value.Read() == 67, "method-hides-inherited-property");
        Check(((Root)value).Read == 61, "hidden-property-through-base-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
