/*
Rules: E12-8-7-1-class-property-type-search; E12-8-7-1-instance-property-type
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Root receiver = actual;
Into: Leaf receiver = actual;
*/
using System;
class Root { public virtual int Value { get { return 1; } } }
class Middle : Root { public override int Value { get { return 3; } } }
class Leaf : Middle { public new string Value { get { return "leaf"; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick(string value) { return 8; }
    static int Pick(object value) { return 9; }
    static void Main()
    {
        Leaf actual = new Leaf();
        Root receiver = actual;
        object result = receiver.Value;
        Check(result is int && (int)result == 3, "property-type-chosen-from-binding-type-declaration");
        Check(Pick(actual.Value) == 8, "nearest-hiding-declaration-has-its-own-property-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
