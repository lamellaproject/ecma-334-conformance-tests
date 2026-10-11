/*
Rules: E15-4-constant-accessibility
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: protected internal const int Code = 809;
Into: private const int Code = 809;
*/
using System;
class Basis { protected internal const int Code = 809; }
class Leaf : Basis { public static int Read() { return Code; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Basis.Code == 809, "protected-internal-constant-in-program");
        Check(Leaf.Read() == 809, "protected-internal-constant-in-derived-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
