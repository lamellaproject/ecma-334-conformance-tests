/*
Rules: E15-2-5-grammar-secondary-constraints-form-2; E15-2-5-depends-direct
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where S : T
Into: 
*/
using System;
class Root { }
class Leaf : Root { }
class Program
{
    static T Up<S,T>(S value) where S : T { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf item = new Leaf();
        Check(Up<Leaf,Root>(item) == item, "direct-parameter-dependency");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
