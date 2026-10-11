/*
Rules: E12-8-11-3-class-type-search; E12-8-11-3-associated-type
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver[5]
Into: ((Base)receiver)[5]
*/
using System;
class Base { public object this[int index] { get { return "base"; } } }
class Derived : Base { public new string this[int index] { get { return "derived"; } } }
class Program
{
    static int checks, failures;
    static int Kind(string value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived();
        var result = receiver[5];
        Check(Kind(result) == 1 && result == "derived", "derived-indexer-associated-type-is-string");
        Base baseView = receiver;
        var other = baseView[5];
        Check(Kind(other) == 2 && (string)other == "base", "base-view-indexer-associated-type-is-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
