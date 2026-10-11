/*
Rules: E15-3-10-1-reserved-hiding; E15-3-10-2-reserve-both-property-accessors
Authority: ECMA-334 7th ed 15.3.10
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new void set_Code(int value)
Into: public new void Write(int value)
*/
using System;
class Root { public int Code { get { return 521; } } }
class Leaf : Root
{
    public int Stored;
    public new void set_Code(int value) { Stored = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        leaf.set_Code(523);
        Check(leaf.Stored == 523, "new-method-hides-absent-but-reserved-property-set-signature");
        Check(leaf.Code == 521, "read-only-base-property-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
