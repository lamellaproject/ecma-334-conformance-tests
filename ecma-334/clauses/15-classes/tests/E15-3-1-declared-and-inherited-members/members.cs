/*
Rules: E15-3-1-declared-and-inherited-members
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Child : Parent
Into: class Child
*/
using System;
class Parent { public int Inherited = 173; }
class Child : Parent { public int Declared = 179; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child value = new Child();
        Check(value.Inherited == 173, "direct-base-member-belongs-to-child");
        Check(value.Declared == 179, "declared-member-belongs-to-child");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
