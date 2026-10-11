/*
Rules: E14-5-3-import-direct-types; E14-3-namespace-using-imports; E14-5-1-using-name-resolution; E14-5-1-grammar-using-directive-2; E14-5-1-using-member-scope; E14-5-3-grammar-using-namespace-directive-1
Authority: ECMA-334 7th ed 14.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using Harbor;
Into: using Canal;
*/
using System;
using Harbor;
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Canal { class Beacon { public const int Code = 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Beacon.Code == 29, "direct-import");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
