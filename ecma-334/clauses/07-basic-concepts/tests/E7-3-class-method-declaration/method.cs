/*
Rules: E7-3-class-method-declaration; E7-4-5-class-method-declaration; E7-4-1-member-inheritance; E7-4-5-class-members
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Read(int number)
Into: public int Renamed(int number)
*/
using System;
class Holder { public int Read(int number) { return number + 1; } }
class Derived : Holder { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Derived().Read(17) == 18, "class-method-declared-and-inherited");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
