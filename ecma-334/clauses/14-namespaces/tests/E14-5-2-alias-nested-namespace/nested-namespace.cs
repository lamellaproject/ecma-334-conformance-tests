/*
Rules: E14-5-2-alias-nested-namespace
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using Scope = Inner;
Into: using Scope = Other;
*/
using System;
namespace Harbor { using Scope = Inner; namespace Inner { class Beacon { public const int Code = 29; } } namespace Other { class Beacon { public const int Code = 31; } } class Reader { public static int Read() { return Scope.Beacon.Code; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Harbor.Reader.Read() == 29, "nested-namespace-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
