/*
Rules: E14-5-3-member-hides-import; E14-5-3-import-existing-type-name
Authority: ECMA-334 7th ed 14.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Beacon { public const int Code = 29; }
Into: class LocalBeacon { public const int Code = 29; }
*/
using System;
using Harbor;
namespace Harbor { class Beacon { public const int Code = 31; } }
class Beacon { public const int Code = 29; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Beacon.Code == 29, "local-member-hides-import");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
