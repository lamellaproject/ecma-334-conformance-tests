/*
Rules: E7-3-class-constant-declaration; E7-4-5-class-constant-declaration; E7-4-1-declared-or-inherited-member; E7-4-1-member-inheritance; E7-4-5-class-members
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Value = 17;
Into: public const int Value = 19;
*/
using System;
class Holder { public const int Value = 17; }
class Derived : Holder { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Derived.Value == 17, "class-constant-declared-and-inherited");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
