/*
Rules: E14-5-2-alias-containing-namespace
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using Scope = Harbor;
Into: using Scope = Canal;
*/
using System;
namespace Harbor { using Scope = Harbor; class Beacon { public const int Code = 29; } class Reader { public static int Read() { return Scope.Beacon.Code; } } }
namespace Canal { class Beacon { public const int Code = 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Harbor.Reader.Read() == 29, "containing-namespace-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
