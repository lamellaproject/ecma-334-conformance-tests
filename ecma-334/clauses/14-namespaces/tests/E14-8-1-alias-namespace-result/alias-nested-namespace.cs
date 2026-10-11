/*
Rules: E14-8-1-alias-namespace-result; E14-8-1-namespace-alias-right-lookup
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Scope::Inner.Beacon.Code
Into: Scope::Other.Beacon.Code
*/
using System;
using Scope = Harbor;
namespace Harbor { namespace Inner { class Beacon { public const int Code = 29; } } namespace Other { class Beacon { public const int Code = 31; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Scope::Inner.Beacon.Code == 29, "alias-nested-namespace");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
