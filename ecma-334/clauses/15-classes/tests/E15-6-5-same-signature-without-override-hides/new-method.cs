/*
Rules: E15-6-5-same-signature-without-override-hides; E15-6-5-override-modifier-required
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new int Read()
Into: public override int Read()
*/
using System;
class Root { public virtual int Read() { return 233; } }
class Leaf : Root { public new int Read() { return 239; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf value = new Leaf();
        Check(((Root)value).Read() == 233, "same-signature-without-override-does-not-replace-base-implementation");
        Check(value.Read() == 239, "same-signature-new-method-hides-base-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
