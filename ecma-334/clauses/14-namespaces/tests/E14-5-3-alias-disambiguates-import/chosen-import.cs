/*
Rules: E14-5-3-alias-disambiguates-import
Authority: ECMA-334 7th ed 14.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using Pick = Harbor.Beacon;
Into: using Pick = Canal.Beacon;
*/
using System;
using Harbor;
using Canal;
using Pick = Harbor.Beacon;
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Canal { class Beacon { public const int Code = 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick.Code == 29, "alias-disambiguates");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
