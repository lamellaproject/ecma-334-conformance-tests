/*
Rules: E14-8-1-qualified-global-access; E14-8-1-global-right-lookup; E14-8-1-global-namespace-result; E14-8-1-grammar-qualified-alias-member-1; E14-8-1-nongeneric-alias-member; E14-8-1-alias-member-access-context
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: global::Harbor.Beacon.Code
Into: Harbor.Beacon.Code
*/
using System;
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Home { class Harbor { } class Reader { public static int Read() { return global::Harbor.Beacon.Code; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Home.Reader.Read() == 29, "global-namespace-despite-shadow");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
