/*
Rules: E15-3-9-1-nonnested-definition; E15-3-9-3-nonnested-default-internal
Authority: ECMA-334 7th ed 15.3.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: namespace Orbit
Into: namespace Elsewhere
*/
using System;
class Token { public static int Read() { return 241; } }
namespace Orbit { class Token { public static int Read() { return 251; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Token.Read() == 241, "compilation-unit-type-accessible-within-assembly");
        Check(Orbit.Token.Read() == 251, "namespace-type-accessible-within-assembly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
