/*
Rules: E7-3-class-field-declaration; E7-4-5-class-field-declaration; E7-4-1-member-inheritance; E7-4-5-class-members
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Value = 23;
Into: public int Value = 29;
*/
using System;
class Holder { public int Value = 23; }
class Derived : Holder { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Derived().Value == 23, "class-field-declared-and-inherited");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
