/*
Rules: E15-3-10-1-reserved-hiding
Authority: ECMA-334 7th ed 15.3.10.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new int get_Code()
Into: public new int Read()
*/
using System;
class Root { public int Code { get { return 503; } } }
class Leaf : Root { public new int get_Code() { return 509; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Check(leaf.get_Code() == 509, "new-method-hides-inherited-property-get-signature");
        Check(leaf.Code == 503, "base-property-still-accessible");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
