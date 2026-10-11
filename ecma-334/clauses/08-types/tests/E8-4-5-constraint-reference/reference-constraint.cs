/*
Rules: E8-4-5-constraint-reference
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Read<Derived, Base>(value)
Into: Read<Derived, Base>(new Derived())
*/
using System;
class Base { }
class Derived : Base { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static U Read<T, U>(T value) where T : U { return value; }
    static void Main()
    {
        Derived value = new Derived();
        Check(Read<Derived, Base>(value) == value, "implicit-reference-satisfies-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
