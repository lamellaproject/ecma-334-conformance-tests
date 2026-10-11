/*
Rules: E8-4-5-constraint-parameter-conversion
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return inner;
Into: return default(U);
*/
using System;
class Base { }
class Derived : Base { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static U Read<T, U>(T value) where T : U { return value; }
    static U Relay<T, U>(T value) where T : U { U inner = Read<T, U>(value); return inner; }
    static void Main()
    {
        Derived value = new Derived();
        Check(Relay<Derived, Base>(value) == value, "type-parameter-conversion-satisfies-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
