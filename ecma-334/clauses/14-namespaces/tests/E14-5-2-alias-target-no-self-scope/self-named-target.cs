/*
Rules: E14-5-2-alias-target-no-self-scope; E14-5-2-using-namespace-alias; E14-5-2-alias-member-name-collision
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using Harbor = Harbor.Inner;
Into: using Harbor = Harbor;
*/
using System;
using Harbor = Harbor.Inner;
namespace Harbor { class Beacon { public const int Code = 29; } namespace Inner { class Beacon { public const int Code = 31; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Harbor::Beacon.Code == 31, "target-resolved-without-new-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
