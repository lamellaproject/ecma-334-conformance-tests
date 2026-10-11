/*
Rules: E8-4-5-constraint-substitution; E8-4-5-constraint-identity
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Read<Base, Base>(value)
Into: Read<Base, Base>(new Base())
*/
using System;
class Base { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static U Read<T, U>(T value) where T : U { return value; }
    static void Main()
    {
        Base value = new Base();
        Check(Read<Base, Base>(value) == value, "identity-satisfies-substituted-type-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
