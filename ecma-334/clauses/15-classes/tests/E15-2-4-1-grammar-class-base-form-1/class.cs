/*
Rules: E15-2-4-1-grammar-class-base-form-1; E15-2-4-1-base-clause-meaning; E15-2-4-2-specified-direct-base; E15-2-4-2-inherits-base-members
Authority: ECMA-334 7th ed 15.2.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Leaf : Root
Into: class Leaf : object
*/
using System;
class Root { public int Reading = 193; }
class Leaf : Root { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Root root = leaf;
        Check(root == leaf, "specified-base-reference-conversion");
        Check(leaf.Reading == 193, "inherited-base-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
