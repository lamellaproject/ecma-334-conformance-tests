/*
Rules: E15-12-static-constructors-not-inherited
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: static Derived() { Program.DerivedCalls++; }
Into: static Derived() { Program.DerivedCalls++; Basis.Touch(); }
*/
using System;
class Basis { static Basis() { Program.BaseCalls++; } public static void Touch() { } }
class Derived : Basis { static Derived() { Program.DerivedCalls++; } public static int ReadOwn() { return 13; } }
class Program
{
    static int checks, failures;
    public static int BaseCalls;
    public static int DerivedCalls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Derived.ReadOwn() == 13, "derived-static-member");
        Check(DerivedCalls == 1 && BaseCalls == 0, "derived-initialization-does-not-inherit-base-constructor");
        Basis.Touch();
        Check(BaseCalls == 1 && DerivedCalls == 1, "separate-base-initialization");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
