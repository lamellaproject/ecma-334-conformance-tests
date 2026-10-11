/*
Rules: E14-5-2-partial-part-name-resolution; E14-5-2-partial-part-directives; E14-5-2-alias-declaration-space
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using Pick = Harbor.Beacon;
Into: using Pick = Canal.Beacon;
*/
using System;
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Canal { class Beacon { public const int Code = 31; } }
namespace Home { using Pick = Harbor.Beacon; partial class Reader { public static int First() { return Pick.Code; } } }
namespace Home { using Pick = Canal.Beacon; partial class Reader { public static int Second() { return Pick.Code; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Home.Reader.First() == 29, "first-part-alias");
        Check(Home.Reader.Second() == 31, "second-part-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
