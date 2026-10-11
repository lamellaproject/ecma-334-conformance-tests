/*
Rules: E15-3-10-1-reserved-hiding; E15-3-10-1-reserve-finalizer-signature
Authority: ECMA-334 7th ed 15.3.10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public new void Finalize()
Into: public new void Finish()
*/
using System;
class Receipt { ~Receipt() { } }
class Leaf : Receipt
{
    public int Calls;
    public new void Finalize() { Calls++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        leaf.Finalize();
        Check(leaf.Calls == 1, "new-method-hides-inherited-finalizer-reservation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
