/*
Rules: E12-8-11-3-exclude-inapplicable; E12-8-11-3-initial-candidates
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: receiver[7]
Into: receiver["seven"]
*/
using System;
class Base { public int this[int index] { get { return 1; } } }
class Derived : Base { public int this[string index] { get { return 2; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived();
        Check(receiver[7] == 1, "inapplicable-derived-indexer-does-not-hide-applicable-base-indexer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
