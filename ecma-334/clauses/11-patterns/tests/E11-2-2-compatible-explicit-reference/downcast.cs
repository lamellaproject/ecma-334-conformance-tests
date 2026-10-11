/*
Rules: E11-2-2-compatible-explicit-reference
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source is Child value
Into: source is Other value
*/
using System;
class Parent { }
class Child : Parent { }
sealed class Other { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Child Find(Parent source) { if (source is Child value) return value; return null; }
    static void Main()
    {
        Parent source = new Child();
        Check(object.ReferenceEquals(Find(source), source), "explicit-reference-compatible");
        Check(Find(new Parent()) == null, "wrong-runtime-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
