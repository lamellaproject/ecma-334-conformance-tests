/*
Rules: E14-8-1-alias-only-left-lookup; E14-8-1-qualified-hidden-alias
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Scope::Beacon.Code
Into: Scope.Beacon.Code
*/
using System;
using Scope = Harbor;
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Home { class Scope { } class Reader { public static int Read() { return Scope::Beacon.Code; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Home.Reader.Read() == 29, "qualifier-finds-hidden-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
