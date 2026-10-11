/*
Rules: E14-5-1-using-order-insignificant; E14-5-2-using-type-alias; E14-5-1-grammar-using-directive-1; E14-5-2-grammar-using-alias-directive-1; E14-5-2-using-alias-members
Authority: ECMA-334 7th ed 14.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using First = Harbor.Beacon;
Into: using First = Canal.Beacon;
*/
using System;
namespace Harbor { class Beacon { public const int Code = 29; } }
namespace Canal { class Beacon { public const int Code = 31; } }
namespace SiteA { using First = Harbor.Beacon; using Second = Canal.Beacon; class Reader { public static int Read() { return First.Code * 100 + Second.Code; } } }
namespace SiteB { using Second = Canal.Beacon; using First = global::Harbor.Beacon; class Reader { public static int Read() { return First.Code * 100 + Second.Code; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(SiteA.Reader.Read() == 2931, "first-order");
        Check(SiteB.Reader.Read() == 2931, "opposite-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
