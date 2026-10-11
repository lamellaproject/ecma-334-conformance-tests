/*
Rules: E15-6-7-abstract-override-virtual
Authority: ECMA-334 7th ed 15.6.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public abstract override int Read();
Into: public new abstract int Read();
*/
using System;
class Source { public virtual int Read() { return 13; } }
abstract class Boundary : Source { public abstract override int Read(); }
class Leaf : Boundary { public override int Read() { return 67; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf value = new Leaf();
        Check(((Source)value).Read() == 67, "abstract-override-preserves-original-virtual-slot");
        Check(((Boundary)value).Read() == 67, "concrete-reimplementation-satisfies-abstract-override");
        Check(new Source().Read() == 13, "original-implementation-still-exists-on-original-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
