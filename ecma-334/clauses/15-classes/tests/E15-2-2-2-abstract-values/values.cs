/*
Rules: E15-2-2-2-abstract-values
Authority: ECMA-334 7th ed 15.2.2.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: abstract class Root
Into: struct Root
*/
using System;
abstract class Root { }
class Leaf : Root { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root empty = null;
        Leaf leaf = new Leaf();
        Root value = leaf;
        Check(empty == null, "abstract-null");
        Check(value == leaf, "abstract-derived-identity");
        Check(value is Leaf, "abstract-concrete-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
