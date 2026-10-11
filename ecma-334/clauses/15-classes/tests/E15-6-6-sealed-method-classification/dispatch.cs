/*
Rules: E15-6-6-sealed-method-classification; E15-6-6-sealed-method-override
Authority: ECMA-334 7th ed 15.6.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public sealed override int Read()
Into: public new int Read()
*/
using System;
class Origin { public virtual int Read() { return 17; } }
class Boundary : Origin { public sealed override int Read() { return 43; } }
class Tip : Boundary { public new int Read() { return 71; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Tip value = new Tip();
        Check(((Origin)value).Read() == 43, "sealed-method-overrides-inherited-virtual-slot");
        Check(((Boundary)value).Read() == 43, "derived-hiding-leaves-sealed-implementation-in-place");
        Check(value.Read() == 71, "hiding-a-sealed-method-is-permitted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
