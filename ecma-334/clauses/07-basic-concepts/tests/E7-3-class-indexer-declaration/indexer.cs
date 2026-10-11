/*
Rules: E7-3-class-indexer-declaration; E7-4-5-class-indexer-declaration; E7-4-1-member-inheritance; E7-4-5-class-members
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: this[int index]
Into: this[string index]
*/
using System;
class Holder { public int this[int index] { get { return 37; } } }
class Derived : Holder { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Derived()[5] == 37, "class-indexer-declared-and-inherited");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
