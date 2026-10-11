/*
Rules: E14-5-2-alias-nested-type; E14-5-2-alias-same-entity
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using Leaf = Harbor.Outer.Inner;
Into: using Leaf = Harbor.Outer.Other;
*/
using System;
using Leaf = Harbor.Outer.Inner;
namespace Harbor { class Outer { public class Inner { } public class Other { } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf value = new Leaf();
        Harbor.Outer.Inner declared = value;
        Check(object.ReferenceEquals(value, declared), "alias-type-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
