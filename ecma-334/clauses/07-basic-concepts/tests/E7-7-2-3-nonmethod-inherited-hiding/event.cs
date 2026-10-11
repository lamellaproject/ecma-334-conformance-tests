/*
Rules: E7-7-2-3-nonmethod-inherited-hiding; E7-7-2-3-inheritance-hiding-definition
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new event Notice Read;
Into: public new event Notice Renamed;
*/
using System;
delegate int Notice();
class Root { public int Read() { return 17; } public int Read(int value) { return 23; } }
class Branch : Root
{
    public new event Notice Read;
    public int Probe() { Read = delegate { return 37; }; return Read(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch value = new Branch();
        Check(value.Probe() == 37, "new-event-visible-in-place-of-base-methods");
        Check(((Root)value).Read() == 17, "hidden-base-method-through-base-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
