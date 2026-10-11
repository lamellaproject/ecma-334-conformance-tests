/*
Rules: E7-3-class-nested-type-declaration; E7-4-5-class-nested-type-declaration; E7-4-1-member-inheritance; E7-4-5-class-members
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Inner
Into: public class Renamed
*/
using System;
class Holder { public class Inner { public int Value = 47; } }
class Derived : Holder { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Derived.Inner().Value == 47, "nested-type-declared-and-inherited");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
