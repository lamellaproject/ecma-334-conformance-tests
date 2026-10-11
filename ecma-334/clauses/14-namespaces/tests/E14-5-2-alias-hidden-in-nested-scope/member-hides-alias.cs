/*
Rules: E14-5-2-alias-hidden-in-nested-scope
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Pick { public const int Code = 31; }
Into: class Different { public const int Code = 31; }
*/
using System;
using Pick = Harbor.Beacon;
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Home { class Pick { public const int Code = 31; } class Reader { public static int Read() { return Pick.Code; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Home.Reader.Read() == 31, "nested-member-hides-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
