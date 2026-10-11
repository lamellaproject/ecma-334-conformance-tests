/*
Rules: E15-2-4-2-transitive-base-classes
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Middle : Root
Into: class Middle : object
*/
using System;
class Root { public int Reading = 233; }
class Middle : Root { }
class Leaf : Middle { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Middle middle = leaf;
        Root root = leaf;
        Check(middle == root, "transitive-base-conversions-preserve-identity");
        Check(leaf.Reading == 233, "transitive-base-member-inheritance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
