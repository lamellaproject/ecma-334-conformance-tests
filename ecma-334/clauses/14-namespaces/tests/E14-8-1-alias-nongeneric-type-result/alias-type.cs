/*
Rules: E14-8-1-alias-nongeneric-type-result
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Scope::Beacon.Code
Into: Scope::Other.Code
*/
using System;
using Scope = Harbor;
namespace Harbor { class Beacon { public const int Code = 29; } class Other { public const int Code = 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Scope::Beacon.Code == 29, "alias-nongeneric-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
